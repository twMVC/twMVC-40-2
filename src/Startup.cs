using System;
using twmvc40_FeatureToggleExample.Entities;
using twmvc40_FeatureToggleExample.Entities.FeatureFilter.Tenant;
using twmvc40_FeatureToggleExample.Extensions;
using twmvc40_FeatureToggleExample.FeatureFilters;
using twmvc40_FeatureToggleExample.Services;
using twmvc40_FeatureToggleExample.Services.Shop;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

namespace twmvc40_FeatureToggleExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFeatureFilterContext, FeatureFilterContext>();
            services.AddScoped<ITenantFeatureContext, TenantFeatureContext>();

            services.AddHttpContextAccessor();

            services.AddFeatureManagement()
                .AddFeatureFilter<TimeWindowFilter>()
                .AddFeatureFilter<BrowserFeatureFilter>()
                .AddFeatureFilter<PercentageFilter>()
                .AddFeatureFilter<FeatureToggleFilter>()
                .AddFeatureFilter<TenantsFeatureFilter>();


            services.AddControllersWithViews();

            services.AddTransient<IShopService, IShopService>(provider =>
            {
                var featureFilterContext = provider.GetRequiredService<IFeatureFilterContext>();
                var featureManager = provider.GetRequiredService<IFeatureManager>();
                var isEnable = featureManager.IsEnabledAsync("FeatureShopService", featureFilterContext)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                var type = string.Empty;
                if (isEnable)
                {
                    type = featureFilterContext.NewType;
                }
                else
                {
                    type = featureFilterContext.OriginType;
                }

                return ServiceFactory.GetService(type);
            });


            // services.AddTransientWithToggle<IShopService>("FeatureShopService");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}