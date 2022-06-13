using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                //error message gdy nie ma produktów w karcie
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
        public IActionResult Index()
        {
            return View(repository.Orders.Where(o => o.Shipped == false).Include(p => p.Lines).ToList());   
        }
        public IActionResult Shipped(int id)
        {
            var order = repository.GetById(id);
            order.Shipped = true;
            repository.Update(id, order);
            return RedirectToAction(nameof(Index));
        }

    }
}
