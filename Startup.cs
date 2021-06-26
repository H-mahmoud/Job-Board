using Job_Board.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Job_Board.Core;
using Job_Board.Core.Profiles;
using Mailjet.Client;
using Microsoft.OpenApi.Models;

namespace Job_Board
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

            services.AddDbContextPool<JobBoardContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("JobBoard")));

            services.AddIdentity<UserModel, IdentityRole>(
                options => options.SignIn.RequireConfirmedEmail = true
                ).AddEntityFrameworkStores<JobBoardContext>().AddDefaultTokenProviders();

            services.AddTransient<Paginator>();

            services.AddAutoMapper(options => {
                options.AddProfile(new JobProfile());
                options.AddProfile(new AccountProfile());
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddHttpClient<IMailjetClient, MailjetClient>(client =>
            {
                client.UseBasicAuthentication(Configuration.GetValue<string>("MailSettings:MJ_APIKEY_PUBLIC"), Configuration.GetValue<string>("MailSettings:MJ_APIKEY_PRIVATE"));
            });

            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Board API", Version = "v1" });
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
                app.UseStatusCodePages();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/NotFound";
                    await next();
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Board API"));

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
