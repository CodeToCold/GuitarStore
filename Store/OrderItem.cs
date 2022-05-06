
namespace Store
{
    public class OrderItem
    {
        public int GuitarId { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int guitarId, int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero");


            GuitarId = guitarId;
            Count = count;
            Price = price;
        }

    }
}
