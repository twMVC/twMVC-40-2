using System;
using twmvc40_FeatureToggleExample.Services;
using twmvc40_FeatureToggleExample.Services.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace twmvc40_FeatureToggleExample.Controllers
{
    public class ApiController : Controller
    {
        private readonly IShopService _shopService;

        public ApiController(IServiceProvider serviceProvider)
        {
            _shopService = serviceProvider.GetRequiredService<IShopService>();
        }

        public JsonResult GetShopData()
        {
            var result = _shopService.GetShopData();
            return new JsonResult(result);
        }
    }
}