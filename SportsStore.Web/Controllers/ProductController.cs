﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;
using SportsStore.Web.Models.ViewModels;

namespace SportsStore.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _repository;
    public int PageSize = 4;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    public ViewResult List(int productPage = 1)
    {
        return View(new ProductsListViewModel
        {
            Products = _repository.Products
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _repository.Products.Count()
            }
        });
    }
}