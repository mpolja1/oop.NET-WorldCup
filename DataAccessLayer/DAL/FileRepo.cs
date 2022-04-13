using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FileRepo
    {

        private const string pathJezikPrvenstvo = @"C:\postavke.txt";
        private const string pathOmiljeniTeam = @"C:\omiljenaekipa.txt";
        private const string pathOmiljeniIgraci = @"C:\omiljeniigraci.txt";

       

        private void CreateIfNonExists(string path)
        {
 
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void SavePostavke(string jezik, string prvenstvo)
        {
            CreateIfNonExists(pathJezikPrvenstvo);
                using (StreamWriter writer = new StreamWriter(pathJezikPrvenstvo))
                {
                    writer.WriteLine(jezik);
                    writer.WriteLine(prvenstvo);

                }  
        }
        public static List<string>LoadPostavke()
        {
            List<string> data = new List<string>(); 
            using (StreamReader reader = new StreamReader(pathJezikPrvenstvo))
            {
                string jezik = reader.ReadLine();
                string prvenstvo = reader.ReadLine();
                data.Add(jezik);
                data.Add(prvenstvo);
            }
            return data;
            
        }
        public void SaveFavoriteTeam(Team team)
        {
            CreateIfNonExists(pathOmiljeniTeam);
            using (StreamWriter writer = new StreamWriter(pathOmiljeniTeam))
            {
                writer.WriteLine($"{team.country}");
            }
        }
        public static string LoadFavoriteTeam()
        {
            using(StreamReader reader = new StreamReader(pathOmiljeniTeam))
            {
                return reader.ReadLine();
            }
        }
        public void SaveFavoritePlayers(List<Player> igraci)
        {
            CreateIfNonExists(pathOmiljeniIgraci);

            File.WriteAllLines(pathOmiljeniIgraci, igraci.Select(igrac => igrac.FormatForFile()));
        }
        public static List<Player> LoadFavoritePlayer()
        {
            List<Player> igraci = new List<Player>();

            string[] lines = File.ReadAllLines(pathOmiljeniIgraci);
            lines.ToList().ForEach(li => igraci.Add(Player.ParsePlayerFromFile(li)));


            return igraci;
        }


    }
}
