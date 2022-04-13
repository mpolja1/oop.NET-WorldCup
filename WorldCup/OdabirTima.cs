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
    public partial class OdabirTima : Form
    {
        private readonly IRepo repo = new ApiRepoMen();
        private readonly IRepo repoW = new ApiRepoWomen();
        FileRepo fileRepo = new FileRepo();
        public OdabirTima()
        {
            InitializeComponent();
            
        }

        private void OdabirTima_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> postavke = FileRepo.LoadPostavke();
                string prvenstvo = postavke[1];

                if (prvenstvo=="Muško")
                {
                    FillAsycMen();
                }
                else
                {
                    FillAsycWomen();
                }
            }
            catch (Exception em)
            {

                MessageBox.Show(em.Message);
            }

            
        }

        private Task<List<Team>> GetAsyncWomenTeams()
        {
            return Task.Run(() => repoW.GetTeams());
        }

        private Task<List<Team>> GetAsyncMenTeams()
        {
            return Task.Run(() => repo.GetTeams());
        }

        private async void FillAsycWomen()
        {
            var teams = await GetAsyncWomenTeams();
            foreach (var item in teams)
            {
                cbTeamList.Items.Add(item);
            }
            cbTeamList.SelectedItem = 0;
        }

        private async void FillAsycMen()
        {
            var teams = await GetAsyncMenTeams();
            foreach (var team in teams)
            {
                cbTeamList.Items.Add(team);
            }
            cbTeamList.SelectedIndex = 0;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            Team team = cbTeamList.SelectedItem as Team;
            fileRepo.SaveFavoriteTeam(team);
            
            Form form = new OmiljeniIgraci();
            form.Show();
            
        }
    }
}
