﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnoMarket.Services.Catalog.Dtos;
using TechnoMarket.Services.Catalog.Services.Interfaces;
using TechnoMarket.Shared.ControllerBases;

namespace TechnoMarket.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var response=await _categoryService.CreateAsync(categoryCreateDto);
            return CreateActionResult(response);
        }




    }
}
