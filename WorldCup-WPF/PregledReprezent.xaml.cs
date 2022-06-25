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
    /// Interaction logic for PregledReprezent.xaml
    /// </summary>
    public partial class PregledReprezent : Page
    {
        private IRepo _repo = new ApiRepoMen();
        private List<Team> teams;
        private Team _favoriteTeam;
        private List<TeamMatch> awayTeams;
        public PregledReprezent()
        {
            InitializeComponent();
   
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetTeamAsync();
            GetAwayTeams();
        }
        private async void GetTeamAsync()
        {
            teams = await _repo.GetTeams();
            foreach (var item in teams)
            {
                favoriteCountry.Items.Add(item);
            }
            _favoriteTeam = teams.Where(x => x.country == "Croatia").FirstOrDefault();
            favoriteCountry.SelectedItem = _favoriteTeam;

        }
        private async void GetAwayTeams()
        {
            awayTeams = await _repo.GetAwayTeams("Nigeria");
            foreach (var team in awayTeams)
            {
                AwayCountrys.Items.Add(team);
            }

        }
    }
}
