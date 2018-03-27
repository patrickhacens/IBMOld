using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace IBMYoung
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
            services.AddDbContext<Db>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Conversor de Temperaturas",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new Contact
                        {
                            Name = "Renato Groffe",
                            Url = "https://github.com/renatogroffe"
                        }
                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(o =>
                 {
                     o.RequireHttpsMetadata = false;
                     o.SaveToken = true;
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                         ValidateAudience = true,
                         ValidAudience = Configuration["Tokens:Audience"],

                         ValidateIssuer = true,
                         ValidIssuer = Configuration["Tokens:Issuer"],

                         ValidateLifetime = true,
                         ClockSkew = TimeSpan.Zero
                     };
                 });

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            app.UseStaticFiles();

            app.UseCors(conf =>
            {
                conf.AllowAnyHeader();
                conf.AllowAnyMethod();
                conf.AllowAnyOrigin();
            });

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Conversor de Temperaturas");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
