using System;
using twmvc40_FeatureToggleExample.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace twmvc40_FeatureToggleExample.Extensions
{
    public static class MyServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddTransientWithToggle<TService>(this IServiceCollection services, string featureName)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            using (var provider = services.BuildServiceProvider())
            {
                Type type;

                var featureFilterContext = provider.GetRequiredService<IFeatureFilterContext>();
                var featureManager = provider.GetRequiredService<IFeatureManager>();
                var isEnable = featureManager.IsEnabledAsync(featureName, featureFilterContext).ConfigureAwait(false).GetAwaiter().GetResult();
                if (isEnable)
                {
                    type = Type.GetType(featureFilterContext.NewType);
                }
                else
                {
                    type = Type.GetType(featureFilterContext.OriginType);
                }

                return services.AddTransient(typeof(TService), type);

            }
        }
    }
}