using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using AutoMapper;
using API.Helpers;
using API.Middleware;
using API.Extensions;

namespace API
{
    public class Startup
    {

        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddApplicationServices();
            services.AddSwaggerDocmention();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // order is very important here
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app.UseSwaggerDocumention();
            //middleware to validate Api
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/error/{0}");


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
