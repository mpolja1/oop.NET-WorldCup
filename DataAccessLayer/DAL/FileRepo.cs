using DataAccessLayer.DAL.Interface;
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
    public class FileRepo : IFile
    {
        private const  string DIR = @"C:\";
        private string pathJezikPrvenstvo = DIR + "postavke.txt";
        private  string pathOmiljeniTeam = DIR + "omiljenaekipa.txt";
        private const string pathOmiljeniIgraci =DIR + "omiljeniigraci.txt";
        private const string pathResolution = DIR +"resolution.txt";


        public FileRepo()
        {
            if (!Directory.Exists(DIR))
            {
                Directory.CreateDirectory(DIR);
            }
        }
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
        public void SaveResolution(string resolution)
        {
            CreateIfNonExists(pathResolution);
            using (StreamWriter writer = new StreamWriter(pathResolution))
            {
                writer.WriteLine(resolution);
               
            }
        }
        public  string LoadResolution()
        {
            string resolution;
            
            using (StreamReader reader = new StreamReader(pathResolution))
            {
                resolution = reader.ReadLine();
            }
            return resolution;
        }
        public  List<string>LoadPostavke()
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
        public  string LoadFavoriteTeam()
        {
            using(StreamReader reader = new StreamReader(pathOmiljeniTeam))
            {
                return reader.ReadLine();
            }
        }
        public void SaveFavoritePlayers(IList<Player>igraci)
        {
            CreateIfNonExists(pathOmiljeniIgraci);
            var json = JsonConvert.SerializeObject(igraci);
          File.WriteAllText(pathOmiljeniIgraci, json);
            //File.WriteAllLines(pathOmiljeniIgraci, igraci.Select(igrac => igrac.FormatForFile()));
        }
        public  List<Player> LoadFavoritePlayers()
        {
            List<Player> igraci = new List<Player>();

            string lines = File.ReadAllText(pathOmiljeniIgraci);
            igraci = JsonConvert.DeserializeObject<List<Player>>(lines);


            return igraci;
        }


    }
}
