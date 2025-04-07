using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatthewEpSol.domain;
using MatthewEpSol.DataAccess;


namespace MatthewEpSol.DataAccess
{
   
    public class PollRepository
    {
        private readonly PollDbContext _context;

        public PollRepository(PollDbContext context)
        {
            _context = context;
        }
    }
}
