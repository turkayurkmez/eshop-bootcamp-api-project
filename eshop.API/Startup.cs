using eshop.API.Security;
using eshop.Data.Context;
using eshop.Data.Repositories;
using eshop.Services;
using eshop.Services.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eshop.API
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

            services.AddControllers()
                    .AddNewtonsoftJson(config =>
                    {
                        config.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });

            var isProduction = Configuration.GetSection("IsProduction").Get<bool>();
            services.AddScoped<IProductService, ProductService>();
            if (isProduction)
            {
                services.AddScoped<IProductRepository, EFProductRepository>();
            }
            else
            {
                services.AddScoped<IProductRepository, FakeProductRepository>();
            }
           
         
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eshop.API", Version = "v1" });
            });
            services.AddAuthentication("Basic")
                    .AddScheme<BasicAuthenticationOption,BasicAuthenticationHandler>("Basic",null);

            //JWT Bearer için aşağıdaki kodları kullandık, Basic'i iptal ettik.

            var bearer = Configuration.GetSection("Bearer");
            var issuer = bearer["Issuer"];
            var audience = bearer["Audience"];
            var securityKey = bearer["SecurityKey"];

            //JWT'nin nasıl üretileceğini ve onaylanacağı kurallarını yazdık
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(option =>
            //        {
            //            option.TokenValidationParameters = new TokenValidationParameters
            //            {                           
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateIssuerSigningKey = true,
            //                ValidIssuer = issuer,
            //                ValidAudience = audience,
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
            //            };
            //        });

            services.AddCors(option => option.AddPolicy("Allow", policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin();           
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyHeader();
              
            }));


            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<EshopDbContext>(option => option.UseSqlServer(connectionString));
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eshop.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Allow");
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
