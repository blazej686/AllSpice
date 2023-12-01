


namespace AllSpice.Services
{
    public class RecipesService
    {

        private readonly RecipesRepository _recipeRepository;

        public RecipesService(RecipesRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _recipeRepository.CreateRecipe(recipeData);
            return recipe;
        }

        internal string DestroyRecipe(int recipeId, string userId)
        {
            Recipe recipe = GetRecipeById(recipeId);

            if (recipe.CreatorId != userId)
            {
                throw new Exception("Not your recipe to delete!");
            }
            _recipeRepository.DestroyRecipe(recipeId);
            return $"{recipeId} has been deleted!";
        }

        internal Recipe EditRecipe(int recipeId, Recipe recipeData)
        {
            Recipe originalRecipe = GetRecipeById(recipeId);

            originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
            originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
            originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
            originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;

            _recipeRepository.EditRecipe(originalRecipe);
            return originalRecipe;
        }

        internal Recipe GetRecipeById(int recipeId)
        {
            Recipe recipe = _recipeRepository.GetRecipeById(recipeId);
            if (recipe == null)
            {
                throw new Exception($"Invalid recipe Id {recipeId}");
            }
            return recipe;
        }

        internal List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _recipeRepository.GetRecipes();
            return recipes;
        }
    }
}