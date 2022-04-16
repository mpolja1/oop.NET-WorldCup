using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class JsonWomen : IRepo
    {
        private const string pathGroupResults = @"C:\Users\Administrator\Desktop\json-endpoints\worldcup.sfg.io\women\group_results.json";
        private const string pathMatches = @"C:\Users\Administrator\Desktop\json-endpoints\worldcup.sfg.io\women\matches.json";
        private const string pathResults = @"C:\Users\Administrator\Desktop\json-endpoints\worldcup.sfg.io\women\results.json";
        private const string pathTeams = @"C:\Users\Administrator\Desktop\json-endpoints\worldcup.sfg.io\women\teams.json";

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvents(string country, List<Match> matches)
        {
            throw new NotImplementedException();
        }

        public List<GroupResults> GetGroupsResults()
        {
            List<GroupResults> list = new List<GroupResults>();
            using (StreamReader r = new StreamReader(pathGroupResults))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<GroupResults>>(json);
            }
            return list;
        }

        public List<Match> GetMatches()
        {
            List<Match> list = new List<Match>();
            using (StreamReader r = new StreamReader(pathMatches))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Match>>(json);
            }
            return list;
        }

        public List<Match> GetMatchesByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public HashSet<Player> GetPlayers(string name)
        {
            throw new NotImplementedException();
        }

        public List<Results> GetResults()
        {
            List<Results> list = new List<Results>();
            using (StreamReader r = new StreamReader(pathResults))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Results>>(json);
            }
            return list;
        }

        public List<Team> GetTeams()
        {
            List<Team> list = new List<Team>();
            using (StreamReader r = new StreamReader(pathTeams))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Team>>(json);
            }
            return list;
        }

        Task<List<Team>> IRepo.GetTeams()
        {
            throw new NotImplementedException();
        }
    }
}
