using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        /*
        ASP.NET Core creates a new
        EFStoreRepository object and uses it to invoke the HomeController constructor to create the controller
        object that will process the HTTP request
        */
        private IStoreRepository repository;
        public int PageSize = 4; //4 products per page
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(int productPage = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .OrderBy(p => p.ProductID)
        .Skip((productPage - 1) * PageSize).Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}