namespace Pricing
{
    public interface IPriceService
    {
        decimal CalculatePrice(List<Item> items, List<IDiscount> ?discounts);
    }
}