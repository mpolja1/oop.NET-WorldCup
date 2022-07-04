using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
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
        
        private IRepo _repo;
        private IFile _repoFile;
       
        private const string HR = "hr", EN = "en";
    
        public OdabirTima()
        {
            InitializeComponent();
            
        }

        private void OdabirTima_Load(object sender, EventArgs e)
        {
            
            try
            {
                _repoFile = RepoFactory.GetFileRepository();

                List<string> postavke = _repoFile.LoadPostavke();
                string prvenstvo = postavke[1];
                _repo = RepoFactory.GetChampionship(prvenstvo);

                if (postavke[0]=="Hrvatski")
                {
                    SetKultura(HR);
                }
                else
                {
                    SetKultura(EN);
                }

                FillAsyc();
                
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

        private async void FillAsyc()
        {
            var teams = await _repo.GetTeams();
            foreach (var item in teams)
            {
                cbTeamList.Items.Add(item);
            }
            cbTeamList.SelectedIndex = 0;
        }

       

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            Team team = cbTeamList.SelectedItem as Team;
            _repoFile.SaveFavoriteTeam(team);
            


            Form form = new OmiljeniIgraci();
            form.Show();
            
            
            
            
        }
    }
}
