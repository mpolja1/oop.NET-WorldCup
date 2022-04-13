using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class UCPlayerStats : UserControl
    {
        public UCPlayerStats()
        {
            InitializeComponent();
        }

        public string FullName { get =>FullName; set => lblFullName.Text=value; }
        public int Goals { get=> Goals; set=> lblGoals.Text=value.ToString(); }
        public int YellowCards { get=>YellowCards ; set=> lblYellowCards.Text=value.ToString(); }

        public Image PlayerPhoto { get=> PlayerPhoto; set=>pbPlayerPhoto.Image=value; }
    }
}
