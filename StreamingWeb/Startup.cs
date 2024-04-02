using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using StreamingAPI.Data;

namespace web_esigalerie
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
                services.AddControllersWithViews();
                services.AddDbContext<StreamingAPIContext>(option => option.UseSqlServer("Server=StreamingAPIContext;Database=localdb#d348d3a2;Trusted_Connection=True;"));
            services.ConfigureApplicationCookie(options =>
            {
                // Chemin d'accès pour les utilisateurs non authentifiés
                options.LoginPath = "/Views/Login";
            });
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
                        pattern: "{controller=Login}/{action=Index}/{id?}");
                   
                });
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images")),
                    RequestPath = "/wwwroot/images"
                });
            }
        }
    }

