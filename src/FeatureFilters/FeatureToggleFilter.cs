using System.Threading.Tasks;
using twmvc40_FeatureToggleExample.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace twmvc40_FeatureToggleExample.FeatureFilters
{
    [FilterAlias("FeatureToggleGroup")]
    public class FeatureToggleFilter : IContextualFeatureFilter<IFeatureFilterContext>
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, IFeatureFilterContext appContext)
        {
            var settings = featureFilterContext.Parameters.Get<FeatureFilterContext>();

            appContext.IsEnable = settings.IsEnable;
            appContext.OriginType = settings.OriginType;
            appContext.NewType = settings.NewType;

            return Task.FromResult(appContext.IsEnable);
        }
    }
}