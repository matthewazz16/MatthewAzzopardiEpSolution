using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using MatthewEpSol.domain;


namespace MatthewEpSol.DataAccess
{
    public class PollFileRepository : IPollRepository
    {
        private readonly string _filePath = "polls.json";

        public void CreatePoll(Poll poll, PollDbContext context)
        {
            var polls = GetPolls(null);

            int maxId = polls.Any() ? polls.Max(p => p.Id) : 0;
            poll.Id = maxId + 1;

            

            polls.Add(poll);


            var json = JsonSerializer.Serialize(polls, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Poll> GetPolls(PollDbContext context)
        {
            if (!File.Exists(_filePath))
            {
                return new List<Poll>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Poll>>(json) ?? new List<Poll>();
        }

        public void Vote(int pollId, int option, PollDbContext context)
        {
            var polls = GetPolls(context);
            var poll = polls.FirstOrDefault(p => p.Id == pollId);

            if (poll != null)
            {
                if (option == 1) poll.Option1VoteCount++;
                else if (option == 2) poll.Option2VoteCount++;
                else if (option == 3) poll.Option3VoteCount++;

                var json = JsonSerializer.Serialize(polls, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
        }

    }
}

