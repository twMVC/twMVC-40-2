using System.Linq;
using System.Threading.Tasks;
using twmvc40_FeatureToggleExample.Entities.FeatureFilter.Browser;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace twmvc40_FeatureToggleExample.FeatureFilters
{
    [FilterAlias("BrowserFilter")]
    public class BrowserFeatureFilter : IFeatureFilter
    {
        private IHttpContextAccessor _httpContextAccessor;

        public BrowserFeatureFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

            var settings = context.Parameters.Get<BrowserFilterSettings>();

            return Task.FromResult(settings.AllowedBrowsers.Any(userAgent.Contains));
        }
    }


}