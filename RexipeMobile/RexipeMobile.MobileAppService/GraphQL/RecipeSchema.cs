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

            Field<RecipeType>(
                "recipe",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "recipeId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("recipeId");
                    return recipeRepo.GetRecipeDetails(id);
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

            Field<ListGraphType<IngredientQuantityType>>("ingredients", resolve: context => recipeRepo.GetRecipeIngredients(context.Source.Id));
        }
    }

    public class IngredientQuantityType : ObjectGraphType<IngredientQuantity>
    {
        public IngredientQuantityType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));

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
            //Name = "";
            //Desc
        }
    }
}
