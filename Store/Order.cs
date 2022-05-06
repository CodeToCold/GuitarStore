using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get; set; }

        private List<OrderItem> items;
        
        public IReadOnlyCollection<OrderItem> Items
        {
             get { return items; }
        }

        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }

        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price * item.Count); }
        }

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;

            this.items = new List<OrderItem>(items);
        }

        public void AddItem(Guitar guitar, int count)
        {
            if (guitar == null)
                throw new ArgumentNullException(nameof(guitar));

            var item = items.SingleOrDefault(item => item.GuitarId == guitar.Id);

            if (item == null)
                items.Add(new OrderItem(guitar.Id, count, guitar.Price));
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(guitar.Id, item.Count + count, guitar.Price));
            }    
        }
    }
}
