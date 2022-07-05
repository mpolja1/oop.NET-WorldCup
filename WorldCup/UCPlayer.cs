using DataAccessLayer;
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
        public Player Player { get; set; }
        public UCPlayer(Player player)
        {
            InitializeComponent();
            this.Player = player;
            SetUCPlayer(Player);
        }

        public Image IconFavoritePlayer { get => IconFavoritePlayer; set => pbFavoritePlayer.Image = value; }
        public Image PlayerImage { get => PlayerImage; set => pbPlayerPhoto.Image = value; }

        public void SetUCPlayer(Player player)
        {
            if (String.IsNullOrEmpty(player.ImagePath))
            {
                pbPlayerPhoto.Image = MojiResursiPhoto.UnkonwPlayer;
            }

            pbPlayerPhoto.ImageLocation = player.ImagePath;
            lblName.Text = player.name;
            lblShirtNumber.Text = player.shirt_number.ToString();
            lblPosition.Text = player.position;
            lblCapitan.Text = player.captain ? "Capitan" : "";

        }

        public  Player ParseFrameToPlayer(UCPlayer UCPlayer)
        {
            return new Player
            {
                position = UCPlayer.Player.position,
                name = UCPlayer.Player.name,
                shirt_number = UCPlayer.Player.shirt_number,
                captain = UCPlayer.Player.captain,
                ImagePath = UCPlayer.Player.ImagePath
                
            };

        }
        public override string ToString()
        {
            return Player.name;
        }

    }
}
