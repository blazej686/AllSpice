


namespace AllSpice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
INSERT INTO
ingredients(name,quantity,recipeId, creatorId)
VALUES(@Name,@Quantity,@RecipeId,@CreatorId);

SELECT
ing.*,
acc.*
FROM ingredients ing
JOIN accounts acc ON ing.creatorId = acc.id
WHERE ing.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
        {
            ingredient.Creator = profile;
            return ingredient;
        },
        ingredientData).FirstOrDefault();
        return ingredient;
    }
}
