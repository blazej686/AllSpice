namespace AllSpice.Services
{
    public class IngredientsService
    {

        private readonly IngredientsRepository _repository;

        public IngredientsService(IngredientsRepository repository, Auth0Provider auth0Provider)
        {
            _repository = repository;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            Ingredient ingredient = _repository.CreateIngredient(ingredientData);
            return ingredient;
        }

        internal Ingredient GetIngredientById(int ingredientId)
        {
            Ingredient ingredient = _repository.GetIngredientById(ingredientId);
            if (ingredient == null)
            {
                throw new Exception($"Invalid Id {ingredientId}");
            }
            return ingredient;
        }

        internal string DestroyIngredient(int ingredientId, string userId)
        {
            Ingredient ingredient = GetIngredientById(ingredientId);

            if (ingredient.CreatorId != userId)
            {
                throw new Exception("Not your Ingredient to delete!");
            }
            _repository.DestroyIngredient(ingredientId);
            return "Ingredient has been deleted!";
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
            return ingredients;
        }
    }
}