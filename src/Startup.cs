﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoAPI.Data;
using TodoAPI.Models;
using GraphQL;
using GraphQL.Types;
using GraphiQl;

namespace TodoAPI
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

            services.AddScoped<TodoQuery>();
            services.AddScoped<TodoMutation>();
            services.AddSingleton<ITodoRepository, TodoRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<TodoType>();
            services.AddTransient<TodoInput>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new TodoSchema(type => (GraphType)sp.GetService(type)) {
                Query = sp.GetService<TodoQuery>(),
            Mutation = sp.GetService<TodoMutation>()});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphiQl("/graphql");
            app.UseMvc();
        }
    }
}
