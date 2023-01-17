using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCDataTrasferToAction.Models;

namespace MVCDataTrasferToAction.Data
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<MVCDataTrasferToAction.Models.Movie> Movie { get; set; } = default!;
    }
}
