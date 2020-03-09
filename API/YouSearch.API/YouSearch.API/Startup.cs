using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using YouSearch.Aplicacao.IoC;
using YouSearch.Aplicacao.IoC.ORMs;
using YouSearch.Aplicacao.IoC.ORMs.EFCore;
using AutoMapper;

namespace YouSearch.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "YouSearch",
                        Version = "v1",
                        Description = "API de procura de Itens do youtube",
                        Contact = new OpenApiContact
                        {
                            Name = "Walter Junior",
                            Url = new Uri("https://github.com/walterjun")
                        }
                    });

                c.ResolveConflictingActions(x => x.First());
            });

            services.ServicosAplicacaoIoC();
            services.InfrastructureORM<EntityFrameworkIoC>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YouSearch");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();

            
        }
    }
}
