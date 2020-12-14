using twmvc40_FeatureToggleExample.Entities.Shop;

namespace twmvc40_FeatureToggleExample.Services.Shop
{
    public class ShopService : IShopService
    {
        public virtual ShopEntity GetShopData()
        {
            return new ShopEntity
            {
                ShopId = 1,
                Name = "ShopName V1"
            };
        }
    }
}