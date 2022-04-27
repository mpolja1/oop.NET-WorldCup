using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class OdabirTima : Form
    {
        private readonly IRepo repo = new ApiRepoMen();
        private readonly IRepo repoW = new ApiRepoWomen();
        FileRepo fileRepo = new FileRepo();

        private const string HR = "hr", EN = "en";
    
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
                if (postavke[0]=="Hrvatski")
                {
                    SetKultura(HR);
                }
                else
                {
                    SetKultura(EN);
                }


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

        private void SetKultura(string jezik)
        {
            CultureInfo culture = new CultureInfo(jezik);

            Thread.CurrentThread.CurrentUICulture = culture;

            this.Controls.Clear();
            InitializeComponent();
        }

        private async void FillAsycWomen()
        {
            var teams = await repoW.GetTeams();
            foreach (var item in teams)
            {
                cbTeamList.Items.Add(item);
            }
            cbTeamList.SelectedIndex = 0;
        }

        private  async void FillAsycMen()
        {
            var teams = await repo.GetTeams();
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
