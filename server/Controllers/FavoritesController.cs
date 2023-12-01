namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {

        private readonly Auth0Provider _auth0Provider;
        private readonly FavoritesService _favoritesService;

        public FavoritesController(Auth0Provider auth0Provider, FavoritesService favoritesService)
        {
            _auth0Provider = auth0Provider;
            _favoritesService = favoritesService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite favorite = _favoritesService.CreateFavorite(favoriteData);
                return Ok(favorite);

            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{favoriteId}")]
        public async Task<ActionResult<string>> DestroyFavorite(int favoriteId)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                string userId = userInfo.Id;
                string message = _favoritesService.DestroyFavorite(favoriteId, userId);
                return Ok(message);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }
}