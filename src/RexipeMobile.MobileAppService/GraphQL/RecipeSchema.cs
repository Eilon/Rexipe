using GraphQL;
using GraphQL.Types;
using RexipeMobile.Models;
using RexipeModels;

namespace RexipeMobile.MobileAppService.GraphQL
{
    public class RecipeSchema : Schema
    {
        public RecipeSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RecipeQuery>();
            //Mutation = new RecipeMutation(recipe);
            //Subscription = new RecipeSubscriptions(recipe);
        }
    }

    public class RecipeQuery : ObjectGraphType
    {
        public RecipeQuery(RecipeRepository recipeRepo)
        {
            Name = "RecipeDb";
            Description = "A database of recipes.";

            Field<ListGraphType<RecipeType>>("recipes", resolve: context => recipeRepo.GetAll(), description: "Recipes in the database.");

            FieldAsync<RecipeType>(
                "recipe",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "recipeId" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("recipeId");
                    return await recipeRepo.GetRecipe(id);
                }
            );
        }
    }

    public class RecipeType : ObjectGraphType<Recipe>
    {
        public RecipeType(RecipeRepository recipeRepo)
        {
            Field(x => x.Id, type: typeof(IdGraphType));

            Field(x => x.Title).Description("The title of the recipe.");
            Field(x => x.ServingsMin).Description("The minimum servings this recipe will produce.");
            Field(x => x.ServingsMax).Description("The maximum servings this recipe will produce.");
            // Tips
            // Images
            // NutritionInfo
            Field(x => x.PrepTime).Description("The time required to do the prep work for the recipe. This is typically active time.");
            Field(x => x.CookTime).Description("The time required to cook the recipe. This is typically passive time.");
            Field(x => x.ReadyTime).Description("The time from start to end for the recipe to be ready.");

            // Author
            FieldAsync<ListGraphType<IngredientQuantityType>>("ingredients", resolve: async context => await recipeRepo.GetRecipeIngredients(context.Source.Id));
            FieldAsync<ListGraphType<RecipeDirectionType>>("directions", resolve: async context => await recipeRepo.GetRecipeDirections(context.Source.Id));
        }
    }

    public class IngredientQuantityType : ObjectGraphType<IngredientQuantity>
    {
        public IngredientQuantityType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));

            Field(x => x.Order);
            Field(x => x.Ingredient, type: typeof(IngredientType)).Description("The ingredient.");
            Field(x => x.Quantity, type: typeof(ItemQuantityType)).Description("The quantity of the ingredient.");
        }
    }

    public class IngredientType : ObjectGraphType<Ingredient>
    {
        public IngredientType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));

            Field(x => x.Name).Description("The name of the ingredient.");
        }
    }

    public class ItemQuantityType : ObjectGraphType<ItemQuantity>
    {
        public ItemQuantityType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));

            Field(x => x.Numerator).Description("The numerator of the ingredient quantity.");
            Field(x => x.Denominator).Description("The denominator of the ingredient quantity.");
            Field(x => x.OtherUnit, nullable: true).Description("The custom unit of the ingredient quantity.");
            Field<IngredientUnitType>("Unit", description: "The unit of the ingredient quantity.");
        }
    }

    public class IngredientUnitType : EnumerationGraphType<IngredientUnit>
    {
        public IngredientUnitType()
        {
        }
    }

    public class RecipeDirectionType : ObjectGraphType<RecipeDirection>
    {
        public RecipeDirectionType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));

            Field(x => x.Order);
            Field(x => x.Direction).Description("The direction.");
        }
    }
}
