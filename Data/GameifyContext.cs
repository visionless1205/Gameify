using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gameify.Models;

namespace Gameify.Data
{
    public class GameifyContext : DbContext
    {
        public GameifyContext (DbContextOptions<GameifyContext> options)
            : base(options)
        {
        }

        public DbSet<Gameify.Models.Game> Game { get; set; } = default!;
        public DbSet<Gameify.Models.Developer> Developer { get; set; } = default!;
        public DbSet<Gameify.Models.Platform> Platform { get; set; } = default!;
    }
}
