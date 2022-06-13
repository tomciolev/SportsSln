using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IStoreRepository repository;
        public ProductController(IStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Products.Include(d => d.Department).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departments = repository.GetDepartments(); 
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Add(product);
                return RedirectToAction("Index");
            }
            return View(new Product());
        }
    }
}


