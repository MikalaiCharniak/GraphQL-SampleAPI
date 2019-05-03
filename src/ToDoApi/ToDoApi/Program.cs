using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoApi.Database;
using ToDoApi.Models;

namespace ToDoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.ToDoItems.AddRange(
                    new ToDoItem()
                    {
                        ToDoItemId = 1,
                        Description = "Make GraphQL Demo",
                        Status = true
                    },
                    new ToDoItem()
                    {
                        ToDoItemId = 2,
                        Description = "Make GraphQL Presentation",
                        Status = true
                    },
                    new ToDoItem()
                    {
                        ToDoItemId = 3,
                        Description = "Make F# Demo",
                        Status = false
                    }
                    );
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
