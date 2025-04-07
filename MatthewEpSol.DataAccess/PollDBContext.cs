using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MatthewEpSol.domain;


namespace MatthewEpSol.DataAccess
{
    
        public class PollDbContext : DbContext
        {
            public PollDbContext(DbContextOptions<PollDbContext> options)
                : base(options)
            {
            }

            public DbSet<Poll> Polls { get; set; }
        }
    }

