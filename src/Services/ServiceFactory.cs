using System;
using twmvc40_FeatureToggleExample.Services.Shop;

namespace twmvc40_FeatureToggleExample.Services
{
    public class ServiceFactory
    {
        public static IShopService GetService(string typeName)
        {
            IShopService instance = null;

            var type = Type.GetType(typeName);
            if (type != null)
            {
                instance = Activator.CreateInstance(type) as IShopService;
            }

            return instance;
        }
    }
}