using Core.Core.Resolvers;
using Core.Utilities.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Repository.Business.Utilities.Security.Encryption;
using Repository.Business.Utilities.Security.JWT;
using Repository.DataAccess.Concrete.EFCore.DbContexts;
using Repository.Entities.Auth;

namespace UI.WebMvcCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<RepositoryContext>();
            //services.AddRazorPages();

            services.AddIdentity<AspNetUser, AspNetRole>(options =>
                {
                    options.Stores.MaxLengthForKeys = 128;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.SignIn.RequireConfirmedAccount = false; // true
                })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<RepositoryContext>();

            //services.AddTransient<IEmailSender, YourEmailSender>();
            //services.AddTransient<IEmailSender, YourSmsSender>();

            var tokenSettings = Configuration.GetSection("TokenSettings").Get<TokenSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenSettings.Issuer,
                        ValidAudience = tokenSettings.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenSettings.SecurityKey)
                    };
                });

            services.AddDependencyResolvers(new ICoreModule[] {
                new CoreModule()
            });

            //services.AddSignalR();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();
            //services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            //            �nem Kodu A��klama Proje Dosyas� Sat�r Gizleme Durumu
            //Uyar� MVC1005 MVC'yi yap�land�rmak i�in "UseMvc" kullan�m�,
            //U� Nokta Y�nlendirme kullan�l�rken desteklenmez.
            //'UseMvc' kullanmaya devam etmek i�in l�tfen 'ConfigureServices'
            //'MvcOptions.EnableEndpointRouting = false' ayarlay�n. UI.WebMvcCore
            //C: \ Users \ AKR3P \ source \ repos \ MimarSoftCamBalkonThree \ UI.WebMvcCore \ Startup.cs
            //104 Etkin

            //app.UseCookiePolicy();
            // If the app uses Session or TempData based on Session:
            // app.UseSession();
            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                        name: "identity",
                        pattern: "Identity/{controller=Account}/{action=Register}/{id?}");

                endpoints.MapRazorPages();
                //endpoints.MapFallbackToPage("/_Host");
                //endpoints.MapHub<SignalRServer>("/signalRServer");
            });
        }
    }
}