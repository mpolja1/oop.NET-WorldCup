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
    public class JsonMen : IRepo
    {
        private static string DIR = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"json-endpoints\worldcup.sfg.io\men\");

        private  string pathMatches = DIR + "matches.json";
        private  string pathResults = DIR+ "results.json";
        private  string pathTeams = DIR+ "teams.json";
 
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
       
        public async Task<List<TeamMatch>> GetAwayTeams(string country)
        {
            List<TeamMatch> opponents = new List<TeamMatch>();
            List<Match> matches = await GetMatches();

            foreach (var match in matches)
            {
                if (match.home_team.country == country || match.away_team.country == country)
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

     
        public async Task<Match> GetMatch(string country1, string country2)
        {
            IList<Match> matches = await GetMatches();
            Match match = new Match();
            foreach (var mec in matches)
            {
                if (mec.home_team_country == country1 && mec.away_team_country == country2 || mec.home_team_country == country2 && mec.away_team_country == country1)
                {
                    match = mec;
                }
            }
            return await Task.Run(() => match);
        }

        public async Task<List<Match>> GetMatches()
        {
            List<Match> list = new List<Match>();
            using (StreamReader r = new StreamReader(pathMatches))
            {
                string json = r.ReadToEnd();
                list =  JsonConvert.DeserializeObject<List<Match>>(json);
            }
            return await Task.Run(() =>
            {
                return list;
            });
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
            
            return await Task.Run(() => matchesSet);
        }

        public async Task<IList<Results>> GetResults()
        {
            List<Results> list = new List<Results>();
            using (StreamReader r = new StreamReader(pathResults))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Results>>(json);
            }
            return await Task.Run(() =>
            {
                return list;
            });
        }

        public async Task<List<Player>> GetStartingEleven(string country1, string country2)
        {
            List<Player> players = new List<Player>();
            List<Match> matches = await GetMatches();

            foreach (var match in matches)
            {
                if (match.home_team.country == country1 && match.away_team.country == country2 || match.home_team_country == country2 && match.away_team_country == country1)
                {
                    foreach (var player in match.home_team_statistics.starting_eleven)
                    {
                        players.Add(player);
                    }
                }
            }
            return await Task.Run(() => players);
        }

        public async Task<List<Team>> GetTeams()
        {
            List<Team> list = new List<Team>();
            using (StreamReader r = new StreamReader(pathTeams))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Team>>(json);
            }
            return await Task.Run(() =>
            {
                return list;
            });
        }

        public  async Task<List<Match>> DajBroj()
        {
            List<Match> matchList = await GetMatches();


            return matchList;
        }
             
       
    }
}
