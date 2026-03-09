using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Models;

namespace Assignment_3.Data
{
    public class Assignment_4Context : DbContext
    {
        public Assignment_4Context (DbContextOptions<Assignment_4Context> options)
            : base(options)
        {
        }

        public DbSet<Assignment_3.Models.Movie> Movie { get; set; } = default!;
    }
}
