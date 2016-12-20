namespace PrettyHair
{
    public class ProductType
    {
        public ProductType()
        {

        }

        public ProductType(int id, double price, string description, int amount)
        {
            Id = id;
            Price = price;
            Description = description;
            Amount = amount;
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
