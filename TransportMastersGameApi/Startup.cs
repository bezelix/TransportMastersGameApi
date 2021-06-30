using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Middleware;
using TransportMastersGameApi.Services;
using TransportMastersGameApi.Models;
using FluentValidation;
using FirstStepsDotNet.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using TransportMastersGameApi.Authorization;

namespace TransportMastersGameApi
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
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();

            services.AddControllers().AddFluentValidation();
            services.AddDbContext<TransportMastersGameDbContext>();
            services.AddAutoMapper(this.GetType().Assembly);

            //Services
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IVehicleService, VehicleService>();

            //Midlewares
            services.AddScoped<RequestTimeMidleware>(); 
            services.AddScoped<ErrorHandlingMiddleware>(); 

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transport Masters Game Api", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>(); 
            app.UseMiddleware<RequestTimeMidleware>();
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
