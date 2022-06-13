using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IStoreRepository repository;
        public AdminController(IStoreRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View();
        }
    }
}
