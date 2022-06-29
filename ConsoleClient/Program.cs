using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    internal class Program
    {
        IRepo repo = new ApiRepoMen();
       

         static async  Task Main(string[] args)
        {

            //FileRepoMen men = new FileRepoMen();
            //IList<Results> results = men.LoadResults();

            //results.ToList().ForEach(Console.WriteLine);


            IRepo repMen = new JsonMen();
            //List<GroupResults> results = repMen.GetGroupsResults();
            //results.ToList().ForEach(Console.WriteLine);

            //List<Match> matches = repMen.GetMatches();
            //matches.ForEach(Console.WriteLine);

            //List<Team> teams = repMen.GetTeams();
            //teams.ForEach(Console.WriteLine);

            IRepo rep = new JsonWomen();
            //List<GroupResults> matches = rep.GetGroupsResults();
            //matches.ForEach(Console.WriteLine);

            //List<Match> matches1 = rep.GetMatches();
            //matches1.ForEach(Console.WriteLine);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //List<Match> matches = repMen.GetMatches();
            ////matches.ForEach(Console.WriteLine);

            //string name = "Croatia";
            ////Susret(name);
            ////GetOficcials();

            ////GetStartingEleven(name, matches);
            ////GetTopScorer(name, matches);
            ////GetByAttendance(matches);
            //HashSet<Player> matchesSet = GetPlayers(name, matches);
            //matchesSet.ToList().ForEach(Console.WriteLine);
            //Stopwatch stopwatch = new Stopwatch();
            //string country = "Nigeria";

            //FileRepo repofile = new FileRepo();

            //IRepo repo = new ApiRepoMen();
            //ispistimova();


            
            
            //mec.ForEach(Console.WriteLine);
            //mec.ForEach(Console.WriteLine);
            //teams.ForEach(Console.WriteLine);
            //stopwatch.Start();
            //HashSet<Player> igraci = GetPlayers(country, mec);

            //List<GroupResults> gr = repo.GetGroupsResults();
            //gr.ForEach(Console.WriteLine);

            // repofile.SaveFavoritePlayers(igraci.ToList());
            //List<Player> igraciii = FileRepo.LoadFavoritePlayer();
            // igraciii.ForEach(Console.WriteLine);

            //List<Event> events = GetAllEvents(country,mec);
            ////events.ForEach(Console.WriteLine);

            //List<Player> statistika = LoadGoalsAndCards(igraci, events);
            //statistika.Sort();
            //statistika.ForEach(Console.WriteLine);
            //stopwatch.Stop();
            //TimeSpan sp = stopwatch.Elapsed;
            //Console.WriteLine($"Duration: {sp.TotalMilliseconds}");
            //igraci.ToList().ForEach(Console.WriteLine);


            //List<Player> players = SortByGoalsAndYellowCard(country);

            //List<Player> igraci = FileRepo.LoadFavoritePlayer();
            //igraci.ForEach(Console.WriteLine);

            IRepo repo = new ApiRepoMen();
            //List<TeamMatch> list = await repo.GetAwayTeams("Croatia");
            //list.ForEach(Console.WriteLine);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.goals);
            //}

            //Console.WriteLine(list.Count);
            //List<Player> list = await repo.GetStartingEleven("France", "Croatia");

            //list.ForEach(Console.WriteLine);

            //Match mec = await repo.GetMatch("Argentina", "Croatia");


            //Console.WriteLine($"{mec.home_team_country} {mec.home_team.goals} vs {mec.away_team.goals} {mec.away_team_country}");

            //mec.home_team_statistics.starting_eleven.ForEach(Console.WriteLine);
            //Console.WriteLine();
            //mec.away_team_statistics.starting_eleven.ForEach(Console.WriteLine);

            //List<string> list = new List<string>();
            //Console.WriteLine(list.Count);

            IList<Results> results = await repo.GetResults();
            results.ToList().ForEach(Console.WriteLine);

        }

        //public async void Ispis()
        //{
        //    List<TeamMatch> utak = await GetAwayTeams("Croatia");
        //    utak.ForEach(Console.WriteLine);
        //}
     
       
        private static List<Player> LoadGoalsAndCards(HashSet<Player> igraci, List<Event> events)
        {
            List<Player> igracipostatistici = new List<Player>();

            foreach (var item in igraci)
            {
                foreach (var eventt in events)
                {
                    if (eventt.type_of_event == "goal" || eventt.type_of_event=="goal-penalty")
                    {
                        if (item.name == eventt.player)
                        {
                            item.BrojGolova++;
                        }
                    }
                    if (eventt.type_of_event == "yellow-card")
                    {
                        if (item.name == eventt.player)
                        {
                            item.BrojZutihKartona++;
                        }
                    }
                }
                igracipostatistici.Add(item);
            }
            return igracipostatistici;
        }
    

    public static List<Event> GetAllEvents(string country, List<Match> mec)
        {
            List<Event> events = new List<Event>();
            
            foreach (var item in mec)
            {
                if (item.home_team_country==country || item.away_team_country==country)
                {
                    foreach (var dogadaj in item.home_team_events )
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

       

        private static HashSet<Player> GetPlayers(string name, List<Match> matches)
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

      

        private static void GetByAttendance(List<Match> matches)
        {
            matches.Sort();
            foreach (var item in matches)
            {
                Console.WriteLine($"{item.location}-{item.attendance} {item.home_team} vs {item.away_team} {item.stage_name}");
            }
        }

        private static void GetTopScorer(string name, List<Match> matches)
        {
            List<Player> igracipoGolovima = new List<Player>();
            foreach (var item in matches)
            {
                if (item.home_team_country == name || item.away_team_country == name)
                {
                    Console.WriteLine($"{item.home_team_country} {item.home_team.goals} vs {item.away_team_country} {item.away_team.goals}");
                    
                    foreach (var homeevent in item.home_team_events)
                    {
                        if (homeevent.type_of_event == "goal" || homeevent.type_of_event == "goal-penalty" || homeevent.type_of_event== 
                            "goal-own")
                        {
                            Console.WriteLine($"{homeevent.player}{homeevent.time}");
                            
                            
                        }
                    }
                    foreach (var awayevent in item.away_team_events)
                    {
                        if (awayevent.type_of_event == "goal" || awayevent.type_of_event == "goal-penalty" || awayevent.type_of_event ==
                            "goal-own")
                        {
                            Console.WriteLine($"{awayevent.player}{awayevent.time}");
                        }

                    }
                    Console.WriteLine();
                }

                
            }
        }

        private static void GetStartingEleven(string name, List<Match> matches)
        {
            foreach (var item in matches)
            {
                if (item.home_team_country == name || item.away_team_country==name)
                {
                    Console.WriteLine($"{item.home_team_country} vs {item.away_team_country}");

                    foreach (var start in item.home_team_statistics.starting_eleven )
                    {
                        Console.WriteLine($"{start}");
                    }
                    Console.WriteLine();
                    foreach (var startaway in item.away_team_statistics.starting_eleven)
                    {
                        Console.WriteLine($"{startaway}");
                    }
                    Console.WriteLine();
                }
                
            }

        }

        //private static void GetOficcials()
        //{
        //    IRepo repMen = new JsonMen();
        //    List<Match> list = repMen.GetMatches();

        //    foreach (var item in list)
        //    {
        //        Console.WriteLine($"{item.home_team_country} vs {item.away_team_country}");
        //        foreach (var off in item.officials)
        //        {
        //            Console.WriteLine($" {off}");
        //        }
        //    }
        //}

        //private static void Susret(string name)
        //{
           
        //        IRepo repMen = new JsonMen();
        //        List<Match> list = repMen.GetMatches();

        //        foreach (var utakmica in list)
        //        {
        //            if (utakmica.home_team_country == name || utakmica.away_team_country == name)
        //            {
        //                Console.WriteLine($"{utakmica.stage_name}---{utakmica.home_team.country}{utakmica.home_team.goals} vs {utakmica.away_team.country}" +
        //                    $"{utakmica.away_team.goals}");
        //            }
        //        }
        //    }
        
    }
}

