namespace Pricing
{
    public class ThreeAtTwoDiscount : IDiscount
    {
        public Guid Id { get; set; }

        public Action<Item> Rule => item => item.Price = 0;

        public void ApplyRule(List<Item> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            var elementsDiscount = items.Count / 3;

            while (elementsDiscount != 0)
            {
                Rule(items.ElementAt(elementsDiscount * 3 - 1));
                elementsDiscount--;
            }
        }
    }
}
