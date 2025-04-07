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
    public class PollFileRepository
    {
        private readonly string _filePath = "polls.json";

        public void CreatePoll(Poll poll)
        {
            var polls = GetPolls();
            polls.Add(poll);

            var json = JsonSerializer.Serialize(polls, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Poll> GetPolls()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Poll>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Poll>>(json) ?? new List<Poll>();
        }
    }
 }

