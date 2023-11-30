
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
    }
}