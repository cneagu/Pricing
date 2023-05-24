namespace Pricing
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public ItemOptions[]? Options { get; set; }

        public ItemCategoty? Categoty { get; set; }

        public IDiscount[]? Discounts { get; set; }
    }
}
