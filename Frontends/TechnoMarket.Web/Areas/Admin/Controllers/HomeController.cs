﻿using Microsoft.AspNetCore.Mvc;
using TechnoMarket.Web.Services.Interfaces;

namespace TechnoMarket.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICatalogService _catalogService;
        public HomeController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }



        public async Task<IActionResult> Index()
        {
            var products = await _catalogService.GetAllProductsAsync();
            ViewBag.TotalProducts = products.Count;

            var categories = await _catalogService.GetAllCategoriesAsync();
            ViewBag.TotalCategories = categories.Count;

            return View();
        }
    }
}
