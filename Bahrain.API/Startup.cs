using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bahrain.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json.Serialization;
using Bahrain.Common;

namespace Bahrain.API
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
            services.AddDbContext<BahrainDataContext>(opt => opt.UseMySQL(Configuration.GetConnectionString("BahrainConnection")));
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<ILoggerFactory, LoggerFactory>(serviceProvider => {
                LogLevel logLevel = Enum.Parse<LogLevel>(Configuration["Logging:LogLevel:Default"]);
                var configureNamedOptions = new ConfigureNamedOptions<ConsoleLoggerOptions>("request-logger-options", null);
                var optionsFactory = new OptionsFactory<ConsoleLoggerOptions>(new []{ configureNamedOptions }, Enumerable.Empty<IPostConfigureOptions<ConsoleLoggerOptions>>());
                var optionsMonitor = new OptionsMonitor<ConsoleLoggerOptions>(optionsFactory, Enumerable.Empty<IOptionsChangeTokenSource<ConsoleLoggerOptions>>(), new OptionsCache<ConsoleLoggerOptions>());
                return new LoggerFactory(new[] { new ConsoleLoggerProvider(optionsMonitor) }, new LoggerFilterOptions { MinLevel = logLevel });
            });
            services.AddScoped<ILogger>(serviceProvider => serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("RequestLogger"));

            services.AddScoped<IATControllerRepo, SqlATControllerRepo>();
            services.AddScoped<IStaffRepo, SqlStaffRepo>();
            services.AddSingleton<IVatsimApi, VatsimApi>(serviceProvider => new VatsimApi(Configuration["VatsimApi:BaseUrl"]));
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthService, AuthService>(serviceProvider => new AuthService(serviceProvider.GetRequiredService<IUserService>(), serviceProvider.GetRequiredService<IVatsimApi>()));
            //services.AddScoped<IATControllerRepo, MockATControllerRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
