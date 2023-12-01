namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {

        private readonly Auth0Provider _auth0Provider;
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(Auth0Provider auth0Provider, IngredientsService ingredientsService)
        {
            _auth0Provider = auth0Provider;
            _ingredientsService = ingredientsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                ingredientData.CreatorId = userInfo.Id;
                Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
                return Ok(ingredient);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{ingredientId}")]
        public async Task<ActionResult<string>> DestroyIngredient(int ingredientId)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                string userId = userInfo.Id;
                string message = _ingredientsService.DestroyIngredient(ingredientId, userId);
                return Ok(message);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

    }
}