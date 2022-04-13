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
    public class ApiRepoMen : IRepo
    {
        private const string apiUrlGroupResults = @"https://world-cup-json-2018.herokuapp.com/teams/results";
        private const string apiUrlMatches= @"https://world-cup-json-2018.herokuapp.com/matches/";
        private const string apiUrlTeams= @"http://world-cup-json-2018.herokuapp.com/teams/";
        private const string apiUrlResults= @"https://world-cup-json-2018.herokuapp.com/teams/results";

        
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
        public HashSet<Player> GetPlayers(string name)
        {
            HashSet<Player> matchesSet = new HashSet<Player>();
            List<Match> matches = GetMatches();

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
     

        public static List<Event> GetAllEvents(string country, List<Match> mec)
        {
            List<Event> events = new List<Event>();

            foreach (var item in mec)
            {
                if (item.home_team_country == country || item.away_team_country == country)
                {
                    foreach (var dogadaj in item.home_team_events)
                    {
                        events.Add(dogadaj);
                    }
                    foreach (var dog in item.away_team_events)
                    {
                        events.Add(dog);
                    }
                }
            }

            return events;
        }

        public List<Match> GetMatchesByCountry(string country)
        {
            List<Match> teams = new List<Match>();
            List<Match> matches = GetMatches();
            foreach (var mec in matches)
            {
                if (mec.home_team_country == country || mec.away_team_country == country)
                {
                    teams.Add(mec);
                }
            }
            return teams;
        }
    }
}


       

