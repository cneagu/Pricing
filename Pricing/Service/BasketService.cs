namespace Pricing
{
    public class BasketService : IPriceService
    {
        public decimal CalculatePrice(List<Item> items, List<IDiscount> ?discounts)
        {
            decimal price = 0;
            if (items == null)
                return price;

            if (items.Any(item => item.Discounts != null))
                ApplyCategoryDiscount(items);

            if(discounts == null)
            {
                price = items.Sum(item => item.Price);
                return price;
            }

            discounts.ForEach(discount => discount.ApplyRule(items));
            price = items.Sum(item => item.Price);

            if (price >= 0)
                return price;

            throw new Exception("invalid operation");
        }

        private void ApplyCategoryDiscount(List<Item> items)
        {
            var itemsWithDiscounts = items.Where(item => item.Discounts != null).ToList();
            Dictionary<Guid, IDiscount> discountsApplayed = new();

            itemsWithDiscounts.ForEach(item =>
            {
                foreach (var discount in item.Discounts)
                {
                    if (discountsApplayed.ContainsKey(discount.Id))
                        continue;

                    discount.ApplyRule(itemsWithDiscounts.Where(item => item.Discounts.FirstOrDefault(d => d.Id == discount.Id) != null).ToList());
                    discountsApplayed.Add(discount.Id, discount);
                }
            });
        }
    }
}
