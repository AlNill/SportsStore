using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepository _repository;
    private Cart _cart;

    public OrderController(IOrderRepository repository, Cart cart)
    {
        _cart = cart;
        _repository = repository;
    }

    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (_cart.Lines.Count() == 0)
            ModelState.AddModelError("", "Sorry, your cart is empty");
        
        if (ModelState.IsValid)
        {
            order.CartLines = _cart.Lines.ToArray();
            _repository.SaveOrder(order);
            return RedirectToAction(nameof(Completed));
        }
        else
        {
            return View(order);
        }        
    }

    public ViewResult Completed()
    {
        _cart.Clear();
        return View();
    }
}
