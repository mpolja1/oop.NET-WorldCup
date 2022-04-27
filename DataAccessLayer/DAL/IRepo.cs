using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepo
    {
         //List<Results>  GetResults();
       Task<List<Team>> GetTeams();
       Task<List<Match>> GetMatches();

       Task<HashSet<Player>> GetPlayers(string name);
       Task<List<Match>> GetMatchesByCountry(string country);

        Task<List<Event>> GetAllEvents(string country, List<Match> mec);
    }
}
