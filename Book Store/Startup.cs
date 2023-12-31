using Book_Store.Data;
using Book_Store.Models.ViewModels;
using Book_Store.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store
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
            services.AddSession(options => {
                options.Cookie.Name = "OpenAIConversationId";
                options.IdleTimeout = TimeSpan.FromDays(30);
                options.Cookie.IsEssential = true;
            });
            services.AddLogging(options => {
                options.AddConsole();
                options.ClearProviders();
            });
            services.AddHttpContextAccessor();

            services.AddControllersWithViews();
            services.AddSignalR();


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("AppDbConnectionString"))
            );
            services.AddDbContext<AuthDbContext>(options => 
                options.UseSqlServer(Environment.GetEnvironmentVariable("AuthDbConnectionString"))
            );
            services.AddDbContext<OpenAIChatContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("OpenAIChatMessagesConnectionString"))
            );

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogAdapter, BlogAdapter>();
            services.AddScoped<IImageRepository, CloudinaryImageRepository>();
            services.AddScoped<IBlogLikesRepository, BlogLikesRepository>();
            services.AddScoped<IOpenAIRepository, OpenAIRepository>();
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

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.MapHub<OpenAIHub>("/openAI");
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<OpenAIHub>("/openAI");
            });
        }
    }

    public class ApplicationLogs
    {
    }
}
