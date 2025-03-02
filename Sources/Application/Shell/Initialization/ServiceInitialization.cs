using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mmu.JassBuddy2.Infrastructure.Settings.Config.Services;
using Mmu.JassBuddy2.Infrastructure.Settings.Provisioning.Models;

namespace Mmu.JassBuddy2.Shell.Initialization
{
    public static class ServiceInitialization
    {
        public static void Initialize(IServiceCollection services, IWebHostEnvironment hostingEnv)
        {
            var config = ConfigurationFactory.Create(typeof(ServiceInitialization).Assembly);
            services.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));

            services
                .AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddHubOptions(opt =>
                {
                    opt.DisableImplicitFromServicesParameters = true; // Required for the file upload, see https://github.com/dotnet/aspnetcore/issues/38842
                });

            services.AddCors();
            services.AddAntiforgery();

            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(730);
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = _ => true;
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
            });

            services.AddOptions();
            services.AddLocalization();
            services.AddAuthorization();

            services.AddControllers().AddJsonOptions(opt =>
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
            );

            services.AddLogging();

            //services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Shell");
        }
    }
}