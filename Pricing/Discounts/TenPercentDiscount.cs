namespace Pricing
{
    public class TenPercentDiscount : IDiscount
    {
        public Guid Id { get; set; }

        public Action<Item> Rule => item => item.Price -= decimal.Multiply(item.Price, 0.1m);

        public void ApplyRule(List<Item> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            items.ForEach(item => Rule(item));
        }
    }
}
