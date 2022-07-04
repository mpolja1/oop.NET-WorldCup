using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL.Interface
{
     public interface IFile
    {
        void SavePostavke(string jezik, string prvenstvo);
       
        void SaveResolution(string resolution);
        
         string LoadResolution();
      
         List<string> LoadPostavke();

        void SaveFavoriteTeam(Team team);

        string LoadFavoriteTeam();

         void SaveFavoritePlayers(IList<Player> igraci);

         List<Player> LoadFavoritePlayers();
        

    }

}
