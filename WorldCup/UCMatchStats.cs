using DataAccessLayer.Models;
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
    public partial class UCMatchStats : UserControl
    {
        public UCMatchStats()
        {
            InitializeComponent();
        }

        #region Properties

        private string location;
        private int attendance;
        private string homeTeam;
        private string awayTeam;

        [Category("Custom Prop")]
        public string Locationn { get => location; set => location = lblLocationn.Text=value; }
       
        [Category("Custom Prop")]
        public string HomeTeam { get => homeTeam;  set => homeTeam = lblHomeTeam.Text=value; }
        [Category("Custom Prop")]
        public int Attendance { get => attendance; set =>  lblAttendance.Text = value.ToString(); }
       
        [Category("Custom Prop")]
        public string AwayTeam { get => awayTeam; set => lblAwayTeam.Text= value; }

        #endregion
    }
}
