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
    public partial class UCPlayer : UserControl
    {
        public UCPlayer()
        {
            InitializeComponent();
        }

     
        public string NamePlayer { get=>NamePlayer; set=>lblName.Text=value; }
        public int ShirtNumber { get => ShirtNumber; set => lblShirtNumber.Text = value.ToString(); }

        public string Position { get=>Position; set=>lblPosition.Text = value; }

        public bool Capitan { get => Capitan; set => lblCapitan.Text = value.ToString(); }
        public Image IconFavoritePlayer { get => IconFavoritePlayer; set => pbFavoritePlayer.Image = value; }
        public Image PlayerImage { get=>PlayerImage; set=> pbPlayerPhoto.Image=value; }


        //public static Player ParseFrameToFile(UCPlayer player)
        //{
        //    return new Player
        //    {
        //        position = player.Position,
        //        BrojGolova = player.b
        //    }

        //}
    }
}
