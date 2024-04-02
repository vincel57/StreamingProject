using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreamingAPI.Models;

namespace StreamingAPI.Data
{
    public class StreamingAPIContext : DbContext
    {
        public StreamingAPIContext (DbContextOptions<StreamingAPIContext> options)
            : base(options)
        {
        }

        public DbSet<StreamingAPI.Models.Anime> Anime { get; set; } = default!;

        public DbSet<StreamingAPI.Models.Client>? Client { get; set; }

        public DbSet<StreamingAPI.Models.Admin>? Admin { get; set; }

        public DbSet<StreamingAPI.Models.Categorie>? Categorie { get; set; }
    }
}
