using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjetoAPI01.Repository.Interfaces;
using ProjetoAPI01.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI01.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionstring = Configuration.GetConnectionString("DBProjetoApi01");

            services.AddTransient<IClienteRepository>
                (map => new ClienteRepository(connectionstring));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de clientes",
                    Description = "Projeto desenvolvido em NET CORE API com Dapper e SqlServer",
                
                    Contact = new OpenApiContact
                    {
                         Name = "Andressa Santana",
                         Url = new Uri("https://www.linkedin.com/in/andressa-santana-718939138/"),
                        Email = "andressapsantana@outlook.com.br"
                    }
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI01");
                
            });

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
