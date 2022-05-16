namespace Store.Web.Models
{
    public class OrderItemModel
    {
        public int guitarId { get; set; }

        public string ModelName { get; set; }

        public string Company { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
