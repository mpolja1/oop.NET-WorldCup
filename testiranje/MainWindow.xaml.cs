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

namespace testiranje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        private IRepo _repo;

        private IFile _repoFile;
        string favoriteTeamLoaded;
        private List<string> settings;

        private List<Results> _results;
        private List<Team> teams;
        private Team _HomeTeam;
        private List<TeamMatch> awayTeams;
        private List<Match> matches;
        private string _awayTeam;
        private Match _match;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                _repoFile = RepoFactory.GetFileRepository();
                favoriteTeamLoaded = _repoFile.LoadFavoriteTeam();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            settings = _repoFile.LoadPostavke();

            string tournament = settings[1];
            _repo = RepoFactory.GetChampionship(tournament);
            teams = await _repo.GetTeams();
            matches = await _repo.GetMatches();
            awayTeams = await _repo.GetAwayTeams(favoriteTeamLoaded);
            AppendHomeTeams();


        }


        private void cbFavoriteCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            try
            {
                cbAwayCountrys.Items.Clear();
                _HomeTeam = (Team)cbFavoriteCountry.SelectedItem;
                awayTeams = AppendAwayTeams(_HomeTeam.country);
                
                
                foreach (var item in awayTeams)
                {
                    cbAwayCountrys.Items.Add(item);
                }
                cbAwayCountrys.SelectedIndex = 0;
            _awayTeam = cbAwayCountrys.Text;
                _match = matches.Where(x => x.home_team_country == _HomeTeam.country && x.away_team_country == _awayTeam || x.home_team_country == _awayTeam && x.away_team_country == _HomeTeam.country).FirstOrDefault();
                lblHomeTeam.Content = _HomeTeam.country;
                lblAwayTeam.Content = _awayTeam;
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

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void cbAwayCountrys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _HomeTeam = (Team)cbFavoriteCountry.SelectedItem;
            _awayTeam = cbAwayCountrys.SelectedItem.ToString();
            

            _match = matches.Where(x => x.home_team_country == _HomeTeam.country && x.away_team_country == _awayTeam || x.home_team_country == _awayTeam && x.away_team_country == _HomeTeam.country).FirstOrDefault();
            lblHomeTeam.Content = _HomeTeam.country;
            lblAwayTeam.Content = _awayTeam;
            if (_match !=null)
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

        }
        private void AppendHomeTeams()
        {
            foreach (var item in teams)
            {
                cbFavoriteCountry.Items.Add(item);
            }
            cbFavoriteCountry.SelectedItem = teams.Where(x => x.country == favoriteTeamLoaded).FirstOrDefault();
        }
        public List<TeamMatch> AppendAwayTeams(string country)
        {
            List<TeamMatch> awayTeams = new List<TeamMatch>();
            foreach (var match in matches)
            {
                if (match.home_team.country == country || match.away_team.country == country)
                {
                    if (match.home_team.country != country)
                    {
                        //cbAwayCountrys.Items.Add(match.home_team);
                        awayTeams.Add(match.home_team);
                    }
                    else
                    {
                        //cbAwayCountrys.Items.Add(match.away_team);
                        awayTeams.Add(match.away_team);
                    }
                }
              

            }
            return awayTeams;
            
        }
    }
}
