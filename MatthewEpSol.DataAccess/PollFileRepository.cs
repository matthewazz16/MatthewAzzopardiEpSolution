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

        public void Vote(int pollId, int option)
        {
            var polls = GetPolls(null);

            var poll = polls.FirstOrDefault(p => p.Id == pollId);
            if (poll != null)
            {
                switch (option)
                {
                    case 1: poll.Option1VoteCount++; break;
                    case 2: poll.Option2VoteCount++; break;
                    case 3: poll.Option3VoteCount++; break;
                }

                var json = JsonSerializer.Serialize(polls, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
        }
    }
 }

