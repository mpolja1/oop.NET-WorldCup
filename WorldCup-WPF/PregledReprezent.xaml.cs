using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
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
    /// Interaction logic for PregledReprezent.xaml
    /// </summary>
    public partial class PregledReprezent : Page
    {
        private IRepo _repo;
        private IFile _repoFile;

        private List<string> settings;

        private List<Results> _results;
        private List<Team> teams;
        private Team _HomeTeam;
        private List<TeamMatch> awayTeams;
        private List<Match> matches;
        private string _awayTeam;
        private Match _match;
        private List<Player> playerImages;

        string favoriteTeam;
        public PregledReprezent()
        {
            InitializeComponent();
            try
            {
                _repoFile = RepoFactory.GetFileRepository();
                favoriteTeam = _repoFile.LoadFavoriteTeam();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                settings = _repoFile.LoadPostavke();

                string tournament = settings[1];
                _repo = RepoFactory.GetChampionship(tournament);
                matches = await _repo.GetMatches();
                _results = (List<Results>)await _repo.GetResults();
                teams = await _repo.GetTeams();
                awayTeams = await _repo.GetAwayTeams(favoriteTeam);
                playerImages = _repoFile.LoadPlayerImages();
                AppendFavoriteTeams();
                GetAwayTeams();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void AppendFavoriteTeams()
        {
            teams.Sort((x, y) => x.country.CompareTo(y.country));
            foreach (var item in teams)
            {
                cbFavoriteCountry.Items.Add(item);
            }
            _HomeTeam = teams.First(x => x.country == favoriteTeam);
            cbFavoriteCountry.SelectedItem = _HomeTeam;

        }
        private void GetAwayTeams()
        {
          
            foreach (var match in matches)
            {
                if (match.home_team.country == _HomeTeam.country || match.away_team.country == _HomeTeam.country)
                {
                    if (match.home_team.country != _HomeTeam.country)
                    {
                        awayTeams.Add(match.home_team);
                    }
                    else
                    {
                        awayTeams.Add(match.away_team);
                    }
                }

            }

            AppendAwayTeams();
            
            awayTeams.Clear();
        }

        private void cbFavoriteCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _HomeTeam = (cbFavoriteCountry.SelectedItem as Team);
            GetAwayTeams();
            

        }
        private void cbAwayCountrys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          ResetFootballField();
            try
            {
                
                if (cbAwayCountrys.SelectedIndex!=-1)
                {
                    
                    _awayTeam = cbAwayCountrys.SelectedItem.ToString();
                    _match = matches.Where(x => x.home_team_country == _HomeTeam.country && x.away_team_country == _awayTeam || x.home_team_country == _awayTeam && x.away_team_country == _HomeTeam.country).FirstOrDefault();

                    if (_match != null)
                    {
                        GetResults();
                        if (golman.Children.Count == 0)
                        {
                            SetPlayersOnField();
                        }

                    }
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "Greska awayselectionchaned");
            }



        }
        public void ResetFootballField()
        {
            foreach (StackPanel item in footbalfield.Children)
            {
                item.Children.Clear();
            }
        }
        public void AppendAwayTeams()
        {
            if (cbAwayCountrys.Items.Count != 0)
            {
                cbAwayCountrys.Items.Clear();
            }

            foreach (var team in awayTeams)
            {
                cbAwayCountrys.Items.Add(team);
            }


            cbAwayCountrys.SelectedIndex = 0;

            _awayTeam = cbAwayCountrys.SelectedItem.ToString();
            

        }
        public void GetResults()
        {
            try
            {
                lblHomeTeam.Content = _HomeTeam.country;
                lblAwayTeam.Content = cbAwayCountrys.SelectedItem.ToString();
                _match = matches.Where(x => x.home_team_country == _HomeTeam.country && x.away_team_country == _awayTeam || x.home_team_country == _awayTeam && x.away_team_country == _HomeTeam.country).FirstOrDefault();

                if (_match != null)
                {
                    if (_HomeTeam.country == _match.away_team_country)
                    {
                        lblHomeTeamResult.Content = _match.away_team.goals.ToString();
                        lblAwayTeamResult.Content = _match.home_team.goals.ToString();

                    }
                    else
                    {
                        lblHomeTeamResult.Content = _match.home_team.goals.ToString();
                        lblAwayTeamResult.Content = _match.away_team.goals.ToString();
                    }

                }
                if (footbalfield.Children.Count == 0)
                {
                    footbalfield.Children.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void lblHomeTeam_MouseMove(object sender, MouseEventArgs e)
        {
            Results teamResult = _results.Where(x => x.country == _HomeTeam.country).FirstOrDefault();
            tbHomeTeamStats.Text = teamResult.ToString();
        }

        private void lblAwayTeam_MouseMove(object sender, MouseEventArgs e)
        {
            Results teamResulta = _results.Where(x => x.country == _awayTeam).FirstOrDefault();
            tbAwayTeamStats.Text = teamResulta.ToString();
        }

        private void SetPlayersOnField()
        {

            if (_HomeTeam.country != _match.home_team_country)
            {
                foreach (var player in _match.away_team_statistics.starting_eleven)
                {
                    GetPlayerImage(player);
                    GetPlayerStats(player, _match.away_team_events);
                    AppendHomePlayerToField(player);
                  
                    
                }

                foreach (var playeraway in _match.home_team_statistics.starting_eleven)
                {
                    GetPlayerImage(playeraway);
                    GetPlayerStats(playeraway, _match.home_team_events);
                    AppendAwayPlayerToField(playeraway);
                   
                }

            }
            else
            {
                foreach (var player in _match.home_team_statistics.starting_eleven)
                {
                    GetPlayerImage(player);
                    AppendHomePlayerToField(player);
                    GetPlayerStats(player, _match.home_team_events);
                    
                }

                foreach (var playeraway in _match.away_team_statistics.starting_eleven)
                {
                    GetPlayerImage(playeraway);
                    AppendAwayPlayerToField(playeraway);
                    GetPlayerStats(playeraway, _match.away_team_events);
                   
                }

            }
        }

        private void GetPlayerImage(StartingEleven player)
        {
            foreach (var imagePlayer in playerImages)
            {
                if (imagePlayer.name.Equals(player.name))
                {
                    player.ImagePath = imagePlayer.ImagePath;
                    break;
                }
            }
        }

        private void AppendAwayPlayerToField(StartingEleven playeraway)
        {
            PlayerOnField plf = new PlayerOnField(playeraway as StartingEleven);

            plf.MouseEnter += PlayerOnFieldSelected;
            plf.MouseLeave += Plf_MouseLeave;

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

        }

        private void AppendHomePlayerToField(StartingEleven player)
        {
            PlayerOnField plf = new PlayerOnField(player);

            plf.MouseEnter += PlayerOnFieldSelected;
            plf.MouseLeave += Plf_MouseLeave;
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

        private void Plf_MouseLeave(object sender, MouseEventArgs e)
        {
            vbPlayerStats.Visibility = Visibility.Hidden;
        }

        private void GetPlayerStats(Player player, List<Event> matchEvents)
        {
            player.BrojGolova = 0;
            player.BrojZutihKartona = 0;
            foreach (var eventt in matchEvents)
            {
                if (eventt.type_of_event == "goal" || eventt.type_of_event == "goal-penalty")
                {
                    if (player.name == eventt.player)
                    {
                        player.BrojGolova++;
                    }
                }
                if (eventt.type_of_event == "yellow-card")
                {
                    if (player.name == eventt.player)
                    {
                        player.BrojZutihKartona++;
                    }
                }
            }

        }
  
        private void PlayerOnFieldSelected(object sender, MouseEventArgs e)
        {
            PlayerOnField playerOnField = (PlayerOnField)sender;
            lblIgracStats.Content = playerOnField.ToString();
            vbPlayerStats.Visibility = Visibility.Visible;


        }
    }
}
