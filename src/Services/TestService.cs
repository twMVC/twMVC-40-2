using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace twmvc40_FeatureToggleExample.Services
{
    public class TestService : ITestService
    {
        private readonly IFeatureManager _featureManager;

        public TestService(IServiceProvider serviceProvider)
        {
            _featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
        }

        /// <summary>
        /// 非同步方法中使用
        /// </summary>
        /// <returns></returns>
        public async Task SampleMethodAsync()
        {
            //// 取得功能是否開啟
            var isEnable = await _featureManager.IsEnabledAsync("SampleFeature");
        }

        /// <summary>
        /// 一般方法中使用
        /// </summary>
        public void SampleMethod()
        {
            //// 取得功能是否開啟
            var isEnable = _featureManager.IsEnabledAsync("SampleFeature")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}