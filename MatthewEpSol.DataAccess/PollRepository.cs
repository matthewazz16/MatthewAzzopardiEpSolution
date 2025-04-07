using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatthewEpSol.domain;
using Microsoft.EntityFrameworkCore;
using MatthewEpSol.DataAccess;


namespace MatthewEpSol.DataAccess
{
   
    public class PollRepository : IPollRepository
    {
        private readonly PollDbContext _context;

        public PollRepository(PollDbContext context)
        {
            _context = context;
        }

        public void CreatePoll(Poll poll, PollDbContext context)
        {
            context.Polls.Add(poll);
            context.SaveChanges();
        }

        public List<Poll> GetPolls(PollDbContext context) { 
            return context.Polls.ToList();
        }

        public void Vote(int pollId, int option, PollDbContext context)
        {
            var poll = context.Polls.FirstOrDefault(p => p.Id == pollId);
            if (poll != null)
            {
                if (option == 1) poll.Option1VoteCount++;
                else if (option == 2) poll.Option2VoteCount++;
                else if (option == 3) poll.Option3VoteCount++;

                context.SaveChanges();
            }
        }
    }
}
