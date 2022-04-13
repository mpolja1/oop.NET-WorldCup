﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Team
    {
        public int id { get; set; }
        public string country { get; set; }
        public object alternate_name { get; set; }
        public string fifa_code { get; set; }
        public int group_id { get; set; }
        public string group_letter { get; set; }

        public override string ToString()
        => $"{country} ({fifa_code})";
    }
}
