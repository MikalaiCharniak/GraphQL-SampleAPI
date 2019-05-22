using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
           : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }
    }
}
