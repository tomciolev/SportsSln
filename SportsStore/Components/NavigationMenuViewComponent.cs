using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    // in html vc:navigation-menu specifies the NavigationMenuViewComponent class
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            // set value of selected category, which is returned by the RouteData property
            ViewBag.SelectedDepartment = RouteData?.Values["department"]; 
            return View(repository.Products
                .Select(x => x.Department.Name)
                .Distinct().OrderBy(x => x));
        }
    }
}
