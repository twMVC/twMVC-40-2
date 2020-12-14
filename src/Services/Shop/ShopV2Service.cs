using twmvc40_FeatureToggleExample.Entities.Shop;

namespace twmvc40_FeatureToggleExample.Services.Shop
{
    public class ShopV2Service : ShopService, IShopService
    {
        public override ShopEntity GetShopData()
        {
            return new ShopV2Entity
            {
                ShopId = 1,
                Name = "ShopName V2",
                UserCount = 100
            };;
        }
    }
}