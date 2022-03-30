using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Test.Models
{
    public class BowlerDataContext : DbContext
    { 
        //Constructor
        public BowlerDataContext (DbContextOptions<BowlerDataContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }


        
    }
}
