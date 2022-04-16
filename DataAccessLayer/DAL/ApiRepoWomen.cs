using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ApiRepoWomen : IRepo
    {
        private const string apiUrlGroupResults = @"http://worldcup.sfg.io/teams/group_results";
        private const string apiUrlMatches = @"http://worldcup.sfg.io/matches";
        private const string apiUrlTeams = @"http://worldcup.sfg.io/teams/";
        private const string apiUrlResults = @"http://worldcup.sfg.io/teams/results";
        public List<GroupResults> GetGroupsResults()
        {
            List<GroupResults> list = new List<GroupResults>();

            var webRequest = WebRequest.Create(apiUrlGroupResults) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var groupresults = sr.ReadToEnd();
                    var matches = JsonConvert.DeserializeObject<List<GroupResults>>(groupresults);
                    foreach (var item in matches)
                    {
                        list.Add(item);
                    }
                }
            }

            return list;
        }
        public List<Match> GetMatches()
        {
            List<Match> list = new List<Match>();

            var webRequest = WebRequest.Create(apiUrlMatches) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var groupresults = sr.ReadToEnd();
                    var matches = JsonConvert.DeserializeObject<List<Match>>(groupresults);
                    foreach (var item in matches)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public List<Results> GetResults()
        {
            List<Results> list = new List<Results>();

            var webRequest = WebRequest.Create(apiUrlTeams) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var groupresults = sr.ReadToEnd();
                    var matches = JsonConvert.DeserializeObject<List<Results>>(groupresults);
                    foreach (var item in matches)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public List<Team> GetTeams()
        {
            List<Team> list = new List<Team>();

            var webRequest = WebRequest.Create(apiUrlTeams) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var groupresults = sr.ReadToEnd();
                    var matches = JsonConvert.DeserializeObject<List<Team>>(groupresults);
                    foreach (var item in matches)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }
        public static HashSet<Player> GetPlayers(string name, List<Match> matches)
        {
            HashSet<Player> matchesSet = new HashSet<Player>();

            foreach (Match item in matches)
            {
                if (item.home_team_statistics.country == name || item.home_team_statistics.country == name)
                {
                    foreach (var igrac in item.home_team_statistics.starting_eleven)
                    {
                        matchesSet.Add(igrac);
                    }
                    foreach (var igrac in item.home_team_statistics.substitutes)
                    {
                        matchesSet.Add(igrac);
                    }

                }
            }

            return matchesSet;
        }

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvents(string country, List<Match> matches)
        {
            throw new NotImplementedException();
        }

        public HashSet<Player> GetPlayers(string name)
        {
            throw new NotImplementedException();
        }

        public List<Match> GetMatchesByCountry(string country)
        {
            throw new NotImplementedException();
        }

        Task<List<Team>> IRepo.GetTeams()
        {
            throw new NotImplementedException();
        }
    }
}
