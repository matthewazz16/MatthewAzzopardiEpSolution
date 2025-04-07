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

        public void Vote(int pollId, int option)
        {
            var poll = _context.Polls.FirstOrDefault(p => p.Id == pollId);

            if (poll != null) {
                switch (option) {
                    case 1:
                        poll.Option1VoteCount++;
                        break;
                    case 2:
                        poll.Option2VoteCount++;
                        break;
                    case 3:
                        poll.Option3VoteCount++;
                        break;
                    default:
                        throw new ArgumentException("Invalid option");

                }
                _context.SaveChanges();

            }
            else
            {
                throw new InvalidOperationException("Poll not found");
            }
        }
    }
}
