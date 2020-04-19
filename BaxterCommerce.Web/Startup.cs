using BaxterCommerce.Data.Base;
using BaxterCommerce.Data.Users;
using BaxterCommerce.Web.Services;
using BaxterCommerce.Web.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaxterCommerce.Web
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
            var config = new ConnectionConfiguration();
            Configuration.GetSection("ConnectionConfiguration").Bind(config);
            services.AddSingleton(config);

            services.AddSingleton<BaseTableConfiguration>(sp => new UserTableConfiguration());
            services.AddSingleton<IPasswordHashing, PasswordHashing>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
