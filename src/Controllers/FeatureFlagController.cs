using System;
using twmvc40_FeatureToggleExample.Entities;
using twmvc40_FeatureToggleExample.Entities.FeatureFilter.Tenant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace twmvc40_FeatureToggleExample.Controllers
{
    public class FeatureFlagController : Controller
    {
        private readonly ILogger<FeatureFlagController> _logger;

        private readonly IFeatureManager _featureManager;

        private readonly IFeatureFilterContext _featureFilterContext;

        private readonly ITenantFeatureContext _tenantFeatureContext;

        public FeatureFlagController(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<FeatureFlagController>>();
            _featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
            _featureFilterContext = serviceProvider.GetRequiredService<IFeatureFilterContext>();
            _tenantFeatureContext = serviceProvider.GetRequiredService<ITenantFeatureContext>();
        }

        public IActionResult Index()
        {
            var isEnableShopService = _featureManager.IsEnabledAsync("FeatureShopService", _featureFilterContext)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (isEnableShopService)
            {

            }

            return View();
        }

        [FeatureGate("NewFeatureFlag")]
        public IActionResult ViewNewFeature()
        {
            return View();
        }

        public IActionResult Random()
        {
            return View();
        }

        public IActionResult TimeWindowFlag()
        {
            return View();
        }
    }
}