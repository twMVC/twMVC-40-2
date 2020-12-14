using System.Threading.Tasks;

namespace twmvc40_FeatureToggleExample.Services
{
    public interface ITestService
    {
       Task SampleMethodAsync();

       void SampleMethod();
    }
}