namespace Pricing
{
    public interface IDiscount
    {
        public Guid Id { get; set; }

        public Action<Item> Rule { get; }

        void ApplyRule(List<Item> items);
    }
}
