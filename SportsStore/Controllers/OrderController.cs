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
        public IActionResult ViewAll()
        {
            return View(repository.Orders.Where(o => o.Shipped == false).Include(p => p.Lines).ToList());   
        }
        public IActionResult Shipped(int id)
        {
            var order = repository.GetById(id);
            order.Shipped = true;
            repository.Update(order);
            return RedirectToAction("ViewAll");
        }
        public ActionResult Details(int id)
        {
            var result = repository.GetById(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = repository.GetById(id);
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            repository.Delete(id);
            return RedirectToAction("ViewAll");
        }
    }
}
