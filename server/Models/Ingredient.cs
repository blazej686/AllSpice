namespace AllSpice.Models
{
    public class Ingredient

    {

        public int Id { get; set; }
        public string creatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
        public Profile Creator { get; set; }

    }
}