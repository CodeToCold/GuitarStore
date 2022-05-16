using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;
using System.Linq;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGuitarRepository guitarRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IGuitarRepository guitarRepository,
                                IOrderRepository orderRepository)
        {
            this.guitarRepository = guitarRepository;   
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = Map(order);

                return View(model);
            }
            return View("Empty");
        }

        private OrderModel Map(Order order)
        {
            var guitarIds = order.Items.Select(item => item.GuitarId);
            var guitars = guitarRepository.GetAllByIds(guitarIds);
            var itemModels = from item in order.Items
                             join guitar in guitars on item.GuitarId equals guitar.Id
                             select new OrderItemModel
                             {
                                 guitarId = guitar.Id,
                                 ModelName = guitar.ModelName,
                                 Company = guitar.Company,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        public IActionResult AddItem(int id)
        {
            var guitar = guitarRepository.GetById(id);

            Order order;
            Cart cart;

            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
           
            order.AddItem(guitar, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
     
            HttpContext.Session.Set(cart);
            
            return RedirectToAction("Index", "Guitar", new { id });
        }
    }
}
