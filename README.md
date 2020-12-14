# twMVC-40-2

# twmvc40-FeatureToggleExample
淺談 Feature toggle 技術與實踐踐範例程式碼

## Microsoft.FeatureManagement

### NuGet 安裝

	Install-Package Microsoft.FeatureManagement
  Install-Package Microsoft.FeatureManagement.AspNetCore

### Startup 設定

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddFeatureManagement()

      services.AddControllersWithViews();
    }

### 使用方式

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


----------

以上。

若有不清楚或是需要進一步協助請再讓我知道。謝謝。
