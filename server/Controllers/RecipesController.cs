
using Microsoft.AspNetCore.Http.HttpResults;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth0Provider;
        private readonly IngredientsService _ingredientsService;

        public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _auth0Provider = auth0Provider;
            _ingredientsService = ingredientsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                recipeData.CreatorId = userInfo.Id;
                Recipe recipe = _recipesService.CreateRecipe(recipeData);
                return Ok(recipe);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        public ActionResult<List<Recipe>> GetRecipes()
        {
            try
            {
                List<Recipe> recipes = _recipesService.GetRecipes();
                return Ok(recipes);

            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipeById(int recipeId)
        {
            try
            {
                Recipe recipe = _recipesService.GetRecipeById(recipeId);
                return Ok(recipe);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPut("{recipeId}")]
        public async Task<ActionResult<Recipe>> EditRecipe(int recipeId, [FromBody] Recipe recipeData)
        {

            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                string userId = userInfo.Id;
                Recipe recipe = _recipesService.EditRecipe(recipeId, recipeData);
                return recipe;
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult<Recipe>> DestroyRecipe(int recipeId)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                string userId = userInfo.Id;
                string message = _recipesService.DestroyRecipe(recipeId, userId);
                return Ok(message);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        [HttpGet("{recipeId}/ingredients")]

        public ActionResult<Recipe> GetIngredientsByRecipeId(int recipeId)
        {
            try
            {
                List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);


                return Ok(ingredients);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }


}
