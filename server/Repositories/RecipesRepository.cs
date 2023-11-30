
namespace AllSpice.Repositories
{
    public class RecipesRepository
    {

        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
INSERT INTO
recipes(title,instructions,imgUrl,category,creatorId)
VALUES(@Title,@Instructions,@ImgUrl,@Category,@CreatorId)

SELECT
rec.*,
acc.*
FROM recipes rec
JOIN accounts acc ON rec.creatorId = acc.id
WHERE rec.id = LAST_INSERT_ID();";

            Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
            {
                recipe.Creator = profile;
                return recipe;
            }, recipeData).FirstOrDefault();
            return recipe;
        }
    }

}