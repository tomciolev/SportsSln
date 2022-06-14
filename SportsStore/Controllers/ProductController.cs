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
        public IActionResult ViewAll()
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
        public ActionResult Details(int id)
        {
            var result = repository.GetById(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = repository.GetById(id);
            ViewBag.Departments = repository.GetDepartments();
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            repository.Update(product);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}


