using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorldCup_WPF
{
    /// <summary>
    /// Interaction logic for PlayerOnField.xaml
    /// </summary>
    public partial class PlayerOnField : UserControl
    {
        Player Player { get; set; }
        public PlayerOnField(Player player)
        {
            InitializeComponent();
            this.Player = player;
            SetPlayer(player);
        }

        private void SetPlayer(Player player)
        {
            lblplayerName.Content = player.name;
            lblplayerNumber.Content = player.shirt_number;
        }

        private void PlayerOnFieldSelected(object sender, MouseEventArgs e)
        {
            PlayerOnField playerOnField = (PlayerOnField)sender;

        }

        public override string ToString()
        => $"{Player.name} {Player.shirt_number}" +
            $" {Player.position}{Environment.NewLine}Kapetan: {Player.captain}" +
            $"{Environment.NewLine}Golovi: {Player.BrojGolova}" +
            $"{Environment.NewLine}Zuti:{Player.BrojZutihKartona}";

       
    }
}
