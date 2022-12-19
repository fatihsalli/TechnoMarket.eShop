﻿using TechnoMarket.Web.Models;
using TechnoMarket.Web.Services.Interfaces;
using TechnoMarket.Web.Services;

namespace TechnoMarket.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services,IConfiguration Configuration) 
        {
            //Options pattern ile oluşturduğumuz ServiceApiSettings classına ulaştık. Buradan path'i alarak ilgili servise ekleyeceğiz.
            var serviceApisettings=Configuration.GetSection(nameof(ServiceApiSettings)).Get<ServiceApiSettings>();

            //Catalog.Api için => HttpClient ile nesne türeterek yeni ürettiğimiz path üzerinden istek yapacağız.
            services.AddHttpClient<ICatalogService, CatalogService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApisettings.GatewayBaseUri}/{serviceApisettings.Catalog.Path}");
            });

        }
    }
}
