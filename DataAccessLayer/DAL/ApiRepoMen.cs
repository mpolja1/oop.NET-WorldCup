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
        //private const string apiUrlGroupResults = @"https://world-cup-json-2018.herokuapp.com/teams/results";
        private const string apiUrlMatches= @"https://world-cup-json-2018.herokuapp.com/matches/";
        private const string apiUrlTeams= @"http://world-cup-json-2018.herokuapp.com/teams/";
        //private const string apiUrlResults= @"https://world-cup-json-2018.herokuapp.com/teams/results";


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
                        Thread.Sleep(TimeSpan.FromSeconds(5));
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
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            return await Task.Run(()=> matchesSet);
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

            return await Task.Run(()=> events);
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
            return await Task.Run(()=> teams);
        }

        
    }
}


       

