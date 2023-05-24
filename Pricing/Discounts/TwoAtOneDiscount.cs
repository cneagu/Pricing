namespace Pricing.Discounts
{
    public class TwoAtOneDiscount : IDiscount
    {
        public Guid Id { get; set; }

        public Action<Item> Rule => item => item.Price = 0;

        public void ApplyRule(List<Item> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            var elementsDiscount = items.Count / 2;

            while (elementsDiscount != 0)
            {
                Rule(items.ElementAt(elementsDiscount * 2 - 1));
                elementsDiscount--;
            }
        }
    }
}
