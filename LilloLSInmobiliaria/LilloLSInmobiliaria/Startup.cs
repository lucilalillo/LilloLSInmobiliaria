using LilloLSInmobiliaria.Models;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LilloLSInmobiliaria
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>//el sitio web valida con cookie
                {
                    options.LoginPath = "/Usuarios/Login";
                    options.LogoutPath = "/Usuarios/Logout";
                    options.AccessDeniedPath = "/Home/Restringido";
                })

            .AddJwtBearer(options =>//la api web valida con token
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["TokenAuthentication:Issuer"],
                    ValidAudience = config["TokenAuthentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(
                        config["TokenAuthentication:SecretKey"])),
                };
            });
            services.AddAuthorization(options =>
            {
                //options.AddPolicy("Empleado", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador", "Empleado"));
                options.AddPolicy("Admin", policy => policy.RequireRole("SuperAdministrador"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador", "SuperAdministrador"));
                options.AddPolicy("SuperAdministrador", policy => policy.RequireClaim(ClaimTypes.Role, "SuperAdministrador"));
                options.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador"));
                options.AddPolicy("Empleado", policy => policy.RequireClaim(ClaimTypes.Role, "Empleado", "Administrador"));
            });
            services.AddMvc();
            services.AddSignalR();//a?ade signalR
                                  //IUserIdProvider permite cambiar el ClaimType usado para obtener el UserIdentifier en Hub
            services.AddSingleton<IUserIdProvider, DefaultUserIdProvider>();
            /*
            //SOLO PARA INYECCION DE DEPENDENCIAS
            Transient objects are always different; a new instance is provided to every controller and every service.
            Scoped objects are the same within a request, but different across different requests.
            Singleton objects are the same for every object and every request.
            */
             services.AddTransient<IRepositorio<Propietario>, RepositorioPropietario>();
             services.AddTransient<IRepositorioPropietario, RepositorioPropietario>();
             services.AddTransient<IRepositorioInquilino, RepositorioInquilino>();
             services.AddTransient<IRepositorio<Inmueble>, RepositorioInmueble>();
             services.AddTransient<IRepositorioInmueble, RepositorioInmueble>();
             //AddTransient<IRepositorio<Pago>, RepositorioPago>();
             //services.AddTransient<IRepositorioPago, RepositorioPago>();
             services.AddTransient<IRepositorioGarante, RepositorioGarante>();
            // services.AddTransient<IRepositorioContrato, RepositorioContrato>();
             //services.AddTransient<IRepositorio<Contrato>, RepositorioContrato>();
             services.AddTransient<IRepositorio<Usuario>, RepositorioUsuario>();
             services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();

            services.AddDbContext<Models.DataContext>(
               options => options.UseSqlServer(config["ConnectionStrings:DefaultConnection"])
           );


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
            // Habilitar CORS
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            // Uso de archivos est?ticos (*.html, *.css, *.js, etc.)
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.None, });
            //Habilita la autorizacion y autenticacion
            app.UseAuthentication();
            app.UseAuthorization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//p?gina amarilla de errores
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("login", "login/{**accion}", new { controller = "Usuarios", action = "Login" });

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

