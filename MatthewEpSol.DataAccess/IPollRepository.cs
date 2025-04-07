using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatthewEpSol.domain;

namespace MatthewEpSol.DataAccess
{
    public interface IPollRepository
    {
        void CreatePoll(Poll poll, PollDbContext context);
        List<Poll> GetPolls(PollDbContext context);

        void Vote(int pollId, int option);
    }
}
