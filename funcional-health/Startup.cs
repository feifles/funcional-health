using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funcional_health.GQL.Queries;
using funcional_health.GQL.Schema;
using funcional_health.GQL.Types;
using funcional_health.Persistance;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphiQl;
using funcional_health.GQL.Mutations;

namespace funcional_health
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
            //Repositories
            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            //Adding AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Adding DbContext
            services.AddDbContext<FuncionalHealthDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddTransient<ContaCorrenteQuery>();
            services.AddTransient<ContaCorrenteMutation>();

            services.AddSingleton<ContaCorrenteType>();
            services.AddSingleton<ContaCorrenteInputType>();

            var sp = services.BuildServiceProvider();

            services.AddSingleton<ISchema>(new FuncionalHealthSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            //services.AddScoped<ISchema, FuncionalHealthSchema>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphiQl("/GraphQL", "/api/ATMGraphQL/");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
