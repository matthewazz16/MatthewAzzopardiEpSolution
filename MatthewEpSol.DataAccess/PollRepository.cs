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
        public void CreatePoll(Poll poll, PollDbContext context)
        {
            context.Polls.Add(poll);
            context.SaveChanges();
        }
    }
}
