using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RexipeModels;
using Xamarin.Essentials;

namespace RexipeMobile.Services
{
    public class HttpRecipeStore : IRecipeStore
    {
        HttpClient client;

        IEnumerable<Recipe> _recipes;

        public HttpRecipeStore()
        {
            client = new HttpClient
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

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/recipe/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Recipe>(json));
            }

            return null;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/recipe/all");
                _recipes = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Recipe>>(json));
            }

            return _recipes;
        }
    }
}
