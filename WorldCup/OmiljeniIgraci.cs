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
        FileRepo filerepo = new FileRepo();
        private List<UCPlayer> igraci;
        string name;
        public OmiljeniIgraci()
        {
            InitializeComponent();
            try
            {
                name = FileRepo.LoadFavoriteTeam();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private  void OmiljeniIgraci_Load(object sender, EventArgs e)
        {
            try
            {

                List<string> postavke = FileRepo.LoadPostavke();

                if (postavke[1] == "Muško")
                {

                    FillAsyncPlayersMen(name);

                }
                else
                {
                    FillAsyncPlayersWomen(name);


                }             
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       
        private async void FillAsyncPlayersMen(string name)
        {
            var data = await repo.GetPlayers(name);
            foreach (var item in data)
            {
                UCPlayer ucp = new UCPlayer();
                ucp.NamePlayer = item.name;
                ucp.ShirtNumber = item.shirt_number;
                ucp.Position = item.position;
                ucp.Capitan = item.captain;
                ucp.PlayerImage = MojiResursiPhoto.UnkonwPlayer;
                ucp.MouseClick += picture_click;
                ucp.MouseDown += flpFavoritePlayers_MouseDown;
                ucp.MouseDoubleClick += choosePicture_click;
                flpAllPlayers.Controls.Add(ucp);
           
            }
            //ako je oznacenn bojom prabaci ih u favorite players
        }
        private async void FillAsyncPlayersWomen(string name)
        {
            var data = await repoW.GetPlayers(name);
            foreach (var item in data)
            {
                UCPlayer ucp = new UCPlayer();
                ucp.NamePlayer = item.name;
                ucp.ShirtNumber = item.shirt_number;
                ucp.Position = item.position;
                ucp.Capitan = item.captain;
                ucp.PlayerImage = MojiResursiPhoto.UnkonwPlayer;
                ucp.MouseDoubleClick += FavoritePlayer_click;
                //ucp.MouseDown += button_MouseDown;

                flpAllPlayers.Controls.Add(ucp);

            }

        }

        private void flpFavoritePlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                StartDnd(sender as UCPlayer);
            }
        }
        private void StartDnd(UCPlayer player)
        {
            
            if (player.BackColor == Color.Yellow)
            {
               
                selectedPlayer = player;
                player.DoDragDrop(player, DragDropEffects.Move);
            }
            
          
        }

        private void FavoritePlayer_click(object sender, EventArgs e)
        {
            selectedPlayer = (UCPlayer)sender;
            
            if (flpFavoritePlayers.Controls.Count<3)
            {
                selectedPlayer.IconFavoritePlayer = MojiResursiPhoto.Star;
                //selectedPlayer.MouseClick += choosePicture_click;
                
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

        private void picture_click(object sender, MouseEventArgs e)
        {

            if (e.Button==MouseButtons.Right)
            {
                selectedPlayer = (UCPlayer)sender;

                if (selectedPlayer.BackColor == Color.Yellow)
                {
                    selectedPlayer.BackColor = Color.Empty;
                }

                else
                {
                    selectedPlayer.BackColor = Color.Yellow;
                } 
            }
        }

        private async void btnStatistic_Click(object sender, EventArgs e)
        {
            Statistika stat = new Statistika();
            filerepo.SaveFavoritePlayers(await repo.GetPlayers(name));
            stat.Show();
            this.Close();
        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
           

            //UCPlayer player = e.Data.GetData(typeof(UCPlayer)) as UCPlayer;

            if (flpFavoritePlayers.Controls.Count < 3 /*||*/ /*!flpFavoritePlayers.Contains(selectedPlayer)*/)
            {
                selectedPlayer.BackColor= Color.Empty;
                
                selectedPlayer.IconFavoritePlayer = MojiResursiPhoto.Star;
                //selectedPlayer.MouseClick += choosePicture_click;
                
                flpFavoritePlayers.Controls.Add(selectedPlayer);
            }
            else
            {
                flpAllPlayers.Controls.Add(selectedPlayer);
                MessageBox.Show("Maximalni broj igraca je 3");
            }
            
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            UCPlayer player = sender as UCPlayer;
            e.Effect = DragDropEffects.Move;
        }

       
    }
}
