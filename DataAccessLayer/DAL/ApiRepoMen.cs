using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ApiRepoMen : IRepo
    {
        
        private const string apiUrlMatches = @"https://world-cup-json-2018.herokuapp.com/matches/";
        private const string apiUrlTeams = @"http://world-cup-json-2018.herokuapp.com/teams/";
        private const string apiUrlResults = @"https://world-cup-json-2018.herokuapp.com/teams/results";


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
                    return await Task.Run(() =>
                    {
                        //Thread.Sleep(5000);
                        return JsonConvert.DeserializeObject<List<Match>>(groupresults);
                    });
                }
            }

        }

        public async Task<List<Team>> GetTeams()
        {
           

            var webRequest = WebRequest.Create(apiUrlTeams) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var teams = sr.ReadToEnd();
                    
                    return await Task.Run(() =>
                    {
                        //Thread.Sleep(5000);
                        return JsonConvert.DeserializeObject<List<Team>>(teams);
                    });

                }
            }

        }
        public async Task<HashSet<Player>> GetPlayers(string country)
        {
            HashSet<Player> matchesSet = new HashSet<Player>();
            List<Match> matches = await GetMatches();

            foreach (Match item in matches)
            {
                if (item.home_team_statistics.country == country || item.home_team_statistics.country == country)
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
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            return await Task.Run(() => matchesSet);
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

        public async Task<List<TeamMatch>> GetAwayTeams(string country)
        {
            List<TeamMatch> opponents = new List<TeamMatch>();
            List<Match> matches = await GetMatches();

            foreach (var match in matches)
            {
                if (match.home_team.country==country || match.away_team.country==country)
                {
                    if (match.home_team.country != country)
                    {
                        opponents.Add(match.home_team);
                    }
                    else
                    {
                        opponents.Add(match.away_team);
                    }
                }
               
            }


            return await Task.Run(() => opponents);
        }

        public async Task<List<Player>> GetStartingEleven(string country1, string country2)
        {
            List<Player> players = new List<Player>();
            List<Match> matches = await GetMatches();

            foreach (var match in matches)
            {
                if (match.home_team.country==country1 && match.away_team.country==country2 || match.home_team_country==country2 && match.away_team_country==country1)
                {
                    foreach (var player in match.home_team_statistics.starting_eleven)
                    {
                        players.Add(player);
                    }
                }
            }
            return await Task.Run(()=> players);
        }

        public async Task<Match> GetMatch(string country1, string country2)
        {
            IList<Match> matches = await GetMatches();
            Match match = new Match();
            foreach (var mec in matches)
            {
                if (mec.home_team_country==country1 && mec.away_team_country==country2 || mec.home_team_country==country2 && mec.away_team_country==country1)
                {
                    match = mec;
                }
            }
            return await Task.Run(()=> match);
        }

        public async Task<IList<Results>> GetResults()
        {
            List<Results> list = new List<Results>();

            var webRequest = WebRequest.Create(apiUrlResults) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var results = sr.ReadToEnd();
                    return await Task.Run(() =>
                    {
                        //Thread.Sleep(5000);
                        return JsonConvert.DeserializeObject<List<Results>>(results);
                    });

                }
            }
        }
    }
}





