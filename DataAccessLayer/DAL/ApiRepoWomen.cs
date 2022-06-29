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
        //private const string apiUrlGroupResults = @"http://worldcup.sfg.io/teams/group_results";
        private const string apiUrlMatches = @"http://worldcup.sfg.io/matches";
        private const string apiUrlTeams = @"http://worldcup.sfg.io/teams/";
        private const string apiUrlResults = @"http://worldcup.sfg.io/teams/results";
        
        public async Task<List<Match>> GetMatches()
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
                    return await Task.Run(()=>{
                        return JsonConvert.DeserializeObject<List<Match>>(groupresults);
                    });
                }
            }
            
        }


        public async Task<List<Team>> GetTeams()
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
                    return await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<List<Team>>(groupresults);
                    });
                }
            }
           
        }
        public async Task<HashSet<Player>> GetPlayers(string name)
        {
            HashSet<Player> matchesSet = new HashSet<Player>();
            List<Match> matches = await GetMatches();

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

            return await Task.Run(()=>  matchesSet);
        }
        public async Task<List<Event>> GetAllEvents(string country, List<Match> mec)
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

            return await Task.Run(() => events);
        }

       
        public async Task<List<Match>> GetMatchesByCountry(string country)
        {
            List<Match> teams = new List<Match>();
            List<Match> matches = await GetMatches();
            foreach (var mec in matches)
            {
                if (mec.home_team_country == country || mec.away_team_country == country)
                {
                    teams.Add(mec);
                }
            }
            return await Task.Run(() => teams);
        }

        public Task<List<TeamMatch>> GetAwayTeams(string country)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetStartingEleven(string country1, string country2)
        {
            throw new NotImplementedException();
        }

        public Task<Match> GetMatch(string country1, string country2)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Results>> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
