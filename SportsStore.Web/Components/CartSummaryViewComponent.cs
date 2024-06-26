﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private Cart _cart;

    public CartSummaryViewComponent(Cart cartService)
    {
        _cart = cartService;
    }

    public IViewComponentResult Invoke()
    {
        return View(_cart);
    }
}
