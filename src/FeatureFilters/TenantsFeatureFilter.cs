using System.Collections;
using System.Threading.Tasks;
using twmvc40_FeatureToggleExample.Entities.FeatureFilter.Tenant;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace twmvc40_FeatureToggleExample.FeatureFilters
{
    [FilterAlias("Tenants")]
    public class TenantsFeatureFilter : IContextualFeatureFilter<ITenantFeatureContext>
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, ITenantFeatureContext appContext)
        {
            var settings = featureFilterContext.Parameters.Get<TenantFilterSettings>();

            appContext.TenantId = settings.AllowedTenants.ToString();

            return Task.FromResult(((IList) settings.AllowedTenants).Contains(appContext.TenantId));
        }
    }
}