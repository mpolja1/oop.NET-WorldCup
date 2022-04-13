using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Player : IComparable<Player>
    {
        private const char DEL = '|';

        public string name { get; set; }
        public bool captain { get; set; }
        public int shirt_number { get; set; }
        public string position { get; set; }
        public int BrojGolova { get; set; }

        public int BrojZutihKartona { get; set; }

        public int CompareTo(Player other)
        {
            return -BrojGolova.CompareTo(other.BrojGolova);
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   name == player.name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }

        public override string ToString()
        {
            return $"{name} {shirt_number} {position} {captain} {BrojGolova}-BrojZutih:{BrojZutihKartona}";
        }

        internal string FormatForFile()
        {
            return $"{name}{DEL}{shirt_number}{DEL}{position}{DEL}{captain}";
        }

        internal static Player ParsePlayerFromFile(string line)
        {
            string[] detalji = line.Split(DEL);
            return new Player 
            {
                name = detalji[0],
                shirt_number = int.Parse(detalji[1]),
                position = detalji[2],
                captain = bool.Parse(detalji[3])
            };
        }
    }
}
