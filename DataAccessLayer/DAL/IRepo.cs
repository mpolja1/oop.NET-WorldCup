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
         List<Results>  GetResults();
       Task<List<Team>> GetTeams();
        List<Match> GetMatches();
        List<GroupResults> GetGroupsResults();

        HashSet<Player> GetPlayers(string name);
        List<Match> GetMatchesByCountry(string country);
    }
}
