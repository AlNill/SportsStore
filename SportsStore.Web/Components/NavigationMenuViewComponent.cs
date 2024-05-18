using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly IProductRepository _repository;

    public NavigationMenuViewComponent(IProductRepository repository)
    {
        _repository = repository;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(_repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x)
            );
    }
}
