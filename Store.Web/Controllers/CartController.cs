using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IGuitarRepository guitarRepository;
        private readonly IOrderRepository orderRepository;

        public CartController(IGuitarRepository guitarRepository,
                                IOrderRepository orderRepository)
        {
            this.guitarRepository = guitarRepository;   
            this.orderRepository = orderRepository;
        }

        public IActionResult Add(int id)
        {         
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

            var guitar = guitarRepository.GetById(id);
            order.AddItem(guitar, 1);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
     
            HttpContext.Session.Set(cart);
            
            return RedirectToAction("Index", "Guitar", new { id = id});
        }
    }
}
