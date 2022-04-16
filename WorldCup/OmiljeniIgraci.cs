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
        private UCPlayer selectedPlayer;
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
                ucp.PlayerImage = MojiResursiPhoto.UnkonwPlayer;
                ucp.MouseDoubleClick += FavoritePlayer_click;
                //ucp.MouseWheel += choosePicture_click;
                flpAllPlayers.Controls.Add(ucp);
           
            }

        }

        private void FavoritePlayer_click(object sender, EventArgs e)
        {

            selectedPlayer = (UCPlayer)sender;
            
            if (flpFavoritePlayers.Controls.Count<3)
            {
                selectedPlayer.IconFavoritePlayer = MojiResursiPhoto.Star;
                selectedPlayer.MouseClick += choosePicture_click;
                flpFavoritePlayers.Controls.Add(selectedPlayer);
            }
            else
            {
                MessageBox.Show("Maximalni broj igraca je 3");
            }
            
        }

        private void choosePicture_click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Application.StartupPath;

            selectedPlayer = (UCPlayer)sender;
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                selectedPlayer.PlayerImage = new Bitmap(ofd.FileName);

            }

        }

        private void picture_click(object sender, EventArgs e)
        {
            if (selectedPlayer != null)
                selectedPlayer.BorderStyle = BorderStyle.None;
            selectedPlayer = (UCPlayer)sender;
            selectedPlayer.BorderStyle = BorderStyle.FixedSingle;
            if (selectedPlayer.BackColor==Color.Yellow)
            {
                selectedPlayer.BackColor = Color.Empty; 
            }

            else
            {
                selectedPlayer.BackColor = Color.Yellow;
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
