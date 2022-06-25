using DataAccessLayer;
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
    /// Interaction logic for Postave.xaml
    /// </summary>
    /// 

    public partial class Postave : Page
    {
        IRepo repo = new ApiRepoMen();
        Match match;

        public Postave()
        {
            InitializeComponent();
           

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DoAsync();
          
            
        }

        public async void DoAsync()
        {
            match = await repo.GetMatch("Argentina", "Croatia");
            SetPlayersOnField();
            
        }

        private void SetPlayersOnField()
        {

            foreach (var player in match.home_team_statistics.starting_eleven)
            {
                PlayerOnField plf = new PlayerOnField();
                plf.lblplayerName.Content = player.name;
                plf.lblplayerNumber.Content = player.shirt_number;

                switch (player.position)
                {
                    case "Goalie":
                        this.golman.Children.Add(plf);
                        break;
                    case "Defender":
                        Obrana.Children.Add(plf);
                        break;
                    case "Midfield":
                        VezniRed.Children.Add(plf);
                        break;
                    case "Forward":
                        Napad.Children.Add(plf);
                        break;

                    default:
                        break;
                }

            }
            foreach (var playeraway in match.away_team_statistics.starting_eleven)
            {
                PlayerOnField plf = new PlayerOnField();
                plf.lblplayerName.Content = playeraway.name;
                plf.lblplayerNumber.Content = playeraway.shirt_number;

                switch (playeraway.position)
                {
                    case "Goalie":
                       AwayGoalie.Children.Add(plf);
                        break;
                    case "Defender":
                        AwayDefender.Children.Add(plf);
                        break;
                    case "Midfield":
                        AwayMidfield.Children.Add(plf);
                        break;
                    case "Forward":
                        AwayForward.Children.Add(plf);
                        break;

                    default:
                        break;
                }

                //foreach (var player in homeTeamPlayers)
                //{
                //    PlayerOnField plf = new PlayerOnField();
                //    plf.lblplayerName.Content = player.name;
                //    plf.lblplayerNumber.Content = player.shirt_number;

                //    switch (player.position)
                //    {
                //        case "Goalie":
                //           this.golman.Children.Add(plf);
                //            break;
                //        case "Defender":
                //            Obrana.Children.Add(plf);
                //            break;
                //        case "Midfield":
                //            VezniRed.Children.Add(plf);
                //            break;
                //        case "Forward":
                //            Napad.Children.Add(plf);
                //            break;

                //        default:
                //            break;
                //    }

            }

            }
        }
        //public void AddUserControl(int broj)
        //{
        //    golman.Children.Add(new PlayerOnField());


        //    for (int i = 0; i < broj; i++)
        //    {
        //        PlayerOnField playerOnField = new PlayerOnField();
        //        playerOnField.lblplayerName.Content = i;

        //        this.Obrana.Children.Add(playerOnField);
        //    }
        //}
    }


