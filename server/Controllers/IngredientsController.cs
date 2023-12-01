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
                ingredientData.creatorId = userInfo.Id;
                Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
                return Ok(ingredient);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

    }
}