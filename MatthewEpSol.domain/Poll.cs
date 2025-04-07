using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEpSol.domain
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Option1Text { get; set; }
        public string Option2Text { get; set; }
        public string Option3Text { get; set; }

        public int Option1VoteCount { get; set; }
        public int Option2VoteCount { get;set; }
        public int Option3VoteCount { get; set;}

        public DateTime DateCreated { get; set; }
    }
}
