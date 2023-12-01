




namespace AllSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _favoritesRepository;

        public FavoritesService(FavoritesRepository favoritesRepository)
        {
            _favoritesRepository = favoritesRepository;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
            return favorite;
        }

        internal Favorite GetFavoriteById(int favoriteId)
        {
            Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteId);
            if (favorite == null)
            {
                throw new Exception($"invalid favorite id {favoriteId}");
            }
            return favorite;
        }

        internal string DestroyFavorite(int favoriteId, string userId)
        {
            Favorite favorite = GetFavoriteById(favoriteId);
            if (favorite.AccountId != userId)
            {
                throw new Exception("Not your Favorite to Delete!");
            }

            _favoritesRepository.DestroyFavorite(favoriteId);
            return "Favorite Deleted!";
        }

        internal List<ProfileFavorite> GetFavoritesByProfileId(string userId)
        {
            List<ProfileFavorite> favorites = _favoritesRepository.GetFavoritesByProfileId(userId);
            return favorites;
        }
    }
}