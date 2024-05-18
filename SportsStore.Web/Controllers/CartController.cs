using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Infrastructure;
using SportsStore.Web.Models;
using SportsStore.Web.Models.ViewModels;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace SportsStore.Web.Controllers;

public class CartController : Controller
{
    private IProductRepository _repository;

    public CartController(IProductRepository repository)
    {
        _repository = repository;
    }

    public RedirectToActionResult AddToCart(int productId, string returnUrl)
    {
        Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart cart = GetCart();
            cart.AddItem(product, 1);
            SaveCart(cart);
        }
        return RedirectToAction("Index", new {returnUrl});
    }

    public RedirectToActionResult RemoveFromCart (int productId, string returnUrl)
    {
        Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart cart = GetCart();
            cart.RemoveLine(product);
            SaveCart(cart);
        }
        return RedirectToAction("Index", new { returnUrl });
    }

    private Cart GetCart()
    {
        var cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        return cart;
    }

    private void SaveCart(Cart cart)
    {
        HttpContext.Session.SetJson("Cart", cart);
    }

    public IActionResult Index(string returnUrl)
    {
        return View(new CartIndexViewModel
        {
            Cart = GetCart(),
            ReturnUrl = returnUrl
        });
    }
}
