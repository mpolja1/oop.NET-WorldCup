using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class OmiljeniIgraci : Form
    {
        private readonly IRepo repo = new ApiRepoMen();
        private readonly IRepo repoW = new ApiRepoWomen();
 
        public OmiljeniIgraci()
        {
            InitializeComponent();
        }

        private void OmiljeniIgraci_Load(object sender, EventArgs e)
        {
            try
            {

                string name = FileRepo.LoadFavoriteTeam();
                List<string> postavke = FileRepo.LoadPostavke();

                if (postavke[1] == "Muško")
                {

                    FillAsyncPlayersMen(name);

                }
                else
                {
                    List<Match> matches = repoW.GetMatches();
                    HashSet<Player> igraci = ApiRepoWomen.GetPlayers(name, matches);
                      
                }             
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private  Task<List<Player>> AsyncPlayer(string name)
        {
            

            return Task.Run(() => {

                Thread.Sleep(TimeSpan.FromSeconds(0));

                return  repo.GetPlayers(name).ToList();
                
                });
        }
        private async void FillAsyncPlayersMen(string name)
        {
            var data = await AsyncPlayer(name);
            foreach (var item in data)
            {
                UCPlayer ucp = new UCPlayer();
                ucp.NamePlayer = item.name;
                ucp.ShirtNumber = item.shirt_number;
                ucp.Position = item.position;
                ucp.Capitan = item.captain;
                flpAllPlayers.Controls.Add(ucp);
               
            }

        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Statistika stat = new Statistika();
            stat.Show();
            this.Close();
        }
    }
}
