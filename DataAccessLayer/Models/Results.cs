using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Results
    {
        private const char Del = '|';
        public int id { get; set; }
        public string country { get; set; }
        public object alternate_name { get; set; }
        public string fifa_code { get; set; }
        public int group_id { get; set; }
        public string group_letter { get; set; }
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
        public int games_played { get; set; }
        public int points { get; set; }
        public int goals_for { get; set; }
        public int goals_against { get; set; }
        public int goal_differential { get; set; }

        internal static Results ParseFromFile(string line)
        {
            string[] lines = line.Split(Del);

            return new Results
            {
                id = int.Parse(lines[0]),
                  country = lines[1],
                  alternate_name = lines[2],
                  fifa_code = lines[3],
                  group_id = int.Parse(lines[4]),
                  group_letter = lines[5],
                  wins = int.Parse(lines[6]),
                  games_played = int.Parse(lines[7]),
                  points = int.Parse(lines[8]),
                  goals_for = int.Parse(lines[9]),
                   goals_against = int.Parse(lines[10]),
                   goal_differential = int.Parse(lines[11]),

            };
        }
        public override string ToString()
       => $"{id}{country}{alternate_name}";
    }
}
