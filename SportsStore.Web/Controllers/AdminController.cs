﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly IProductRepository _productRepository;

    public AdminController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        return View(_productRepository.Products);
    }

    public ViewResult Edit(int productId)
    {
        return View(_productRepository.Products.FirstOrDefault(p => p.ProductID == productId));
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if(ModelState.IsValid)
        {
            _productRepository.SaveProduct(product);
            TempData["message"] = $"{product.Name} has been saved";
            return RedirectToAction("Index");
        }
        else
        {
            return View(product);
        }
    }

    public ViewResult Create() => View("Edit", new Product());

    [HttpPost]
    public IActionResult Delete(int productId)
    {
        Product deletedProduct = _productRepository.DeleteProduct(productId);
        if(deletedProduct != null)
        {
            TempData["message"] = $"{deletedProduct.Name} was deleted";
        }
        return RedirectToAction("Index");
    }
}
