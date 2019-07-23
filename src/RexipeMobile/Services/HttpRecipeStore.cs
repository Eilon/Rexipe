using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Newtonsoft.Json;
using RexipeModels;
using Xamarin.Essentials;

namespace RexipeMobile.Services
{
    public class HttpRecipeStore : IRecipeStore
    {
        private readonly HttpClient _httpClient;
        private IEnumerable<Recipe> _recipes;

        public HttpRecipeStore()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}/")
            };

            _recipes = new List<Recipe>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        //public async Task<bool> AddRecipeAsync(Recipe recipe)
        //{
        //    if (recipe == null || !IsConnected)
        //        return false;

        //    var serializedRecipe = JsonConvert.SerializeObject(recipe);

        //    var response = await client.PostAsync($"api/recipe", new StringContent(serializedRecipe, Encoding.UTF8, "application/json"));

        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<bool> UpdateRecipeAsync(Recipe recipe)
        //{
        //    if (recipe == null || !IsConnected)
        //        return false;

        //    var serializedRecipe = JsonConvert.SerializeObject(recipe);
        //    var buffer = Encoding.UTF8.GetBytes(serializedRecipe);
        //    var byteContent = new ByteArrayContent(buffer);

        //    var response = await client.PutAsync(new Uri($"api/recipe/{recipe.Id}"), byteContent);

        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<bool> DeleteRecipeAsync(int id)
        //{
        //    if (!IsConnected)
        //        return false;

        //    var response = await client.DeleteAsync($"api/recipe/{id}");

        //    return response.IsSuccessStatusCode;
        //}

        public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            if (IsConnected)
            {
                var json = await _httpClient.GetStringAsync($"api/recipe/{recipeId}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Recipe>(json));
            }

            return null;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await _httpClient.GetStringAsync($"api/recipe/all");
                _recipes = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Recipe>>(json));
            }

            return _recipes;
        }

        public async Task<(IEnumerable<IngredientQuantity>, IEnumerable<RecipeDirection>)?> GetRecipeDetailsAsync(int recipeId)
        {
            if (IsConnected)
            {
                if (App.UseGraphQL)
                {
                    var recipeGraphQLRequest = new GraphQLRequest
                    {
                        Query = string.Format(CultureInfo.InvariantCulture, @"
{{
  recipe(recipeId: {0}) {{
    ingredients {{
      ingredient {{
        name
      }}
      quantity {{
        numerator
        denominator
        otherUnit
        unit
      }}
    }}
    directions
    {{
      direction
    }}
  }}
}}
                ", recipeId),
                    };

                    var graphQLClient = new GraphQLClient(App.AzureBackendUrl + "/graphql");
                    var graphQLResponse = await graphQLClient.PostAsync(recipeGraphQLRequest);
                    var recipeWithDetails = graphQLResponse.GetDataFieldAs<Recipe>("recipe");

                    return (recipeWithDetails.Ingredients, recipeWithDetails.Directions);
                }
                else
                {
                    var ingredientsJson = await _httpClient.GetStringAsync($"api/recipe/{recipeId}/ingredients");
                    var ingredients = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<IngredientQuantity>>(ingredientsJson));

                    var directionsJson = await _httpClient.GetStringAsync($"api/recipe/{recipeId}/directions");
                    var directions = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<RecipeDirection>>(directionsJson));

                    return (ingredients, directions);
                }
            }

            return null;
        }
    }
}
