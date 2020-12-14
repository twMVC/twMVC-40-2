namespace twmvc40_FeatureToggleExample.Entities
{
    public interface IFeatureFilterContext
    {
        bool IsEnable { get; set; }

        string OriginType { get; set; }

        string NewType { get; set; }
    }
}