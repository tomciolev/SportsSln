using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository repository;
        public DepartmentController(IDepartmentRepository repo)
        {
            repository = repo;
        }
        public IActionResult ViewAll()
        {
            return View(repository.Departments);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                repository.Add(department);
                return RedirectToAction("ViewAll");
            }
            return View(new Department());
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
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            repository.Update(department);
            return RedirectToAction("ViewAll");
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
