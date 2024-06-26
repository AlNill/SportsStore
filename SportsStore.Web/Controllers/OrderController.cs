﻿using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    public ViewResult List() =>
        View(_repository.Orders.Where(o => !o.Shipped));

    [HttpPost]
    [Authorize]
    public IActionResult MarkShipped(int orderID)
    {
        Order order = _repository.Orders.FirstOrDefault(o => o.OrderId == orderID);
        if(order != null)
        {
            order.Shipped = true;
            _repository.SaveOrder(order);
        }
        return RedirectToAction(nameof(List));
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
