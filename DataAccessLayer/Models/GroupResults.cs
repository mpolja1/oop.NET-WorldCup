using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class GroupResults
    {
        public int id { get; set; }
        public string letter { get; set; }
        public List<Results> ordered_teams { get; set; }

        public override string ToString()
        => $"{id}{letter}";
    }
}
