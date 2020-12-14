namespace twmvc40_FeatureToggleExample.Entities
{
    public class FeatureFilterContext : IFeatureFilterContext
    {
        public bool IsEnable { get; set; }

        public string OriginType { get; set; } = null;

        public string NewType { get; set; } = null;
    }
}