using eCommerceReplacementProject.DataRepository;
using eCommerceReplacementProject.Users.Data;
using eCommerceReplacementProject.Users.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceReplacementProject.Web
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
            var _connectionConfiguration = new ConnectionConfiguration
            {
                ConnectionString = "Data Source = Silver; Initial Catalog = eComm; Integrated Security = True"
            };

            services.AddSingleton<IPasswordHashing, PasswordHashing>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>(
                sp => new UserRepository(_connectionConfiguration, new UserTableConfiguration()));

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
