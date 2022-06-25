using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
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
        private IRepo _repo;
        private IFile _fileRepo;

        List<string> postavke;
        string country;

        private UCPlayer selectedPlayer;
        private List<UCPlayer> selectedUCPlayers = new List<UCPlayer>();


        public OmiljeniIgraci()
        {
            InitializeComponent();
            _fileRepo = RepoFactory.GetFileRepository();
        }

        private void OmiljeniIgraci_Load(object sender, EventArgs e)
        {
            try
            {

                postavke = _fileRepo.LoadPostavke();
                country = _fileRepo.LoadFavoriteTeam();

                _repo = RepoFactory.GetChampionship(postavke[1]);
                FillAsyncPlayers(country);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private async void FillAsyncPlayers(string country)
        {
            var data = await _repo.GetPlayers(country);

            foreach (var item in data)
            {
                UCPlayer ucp = new UCPlayer();
                ucp.NamePlayer = item.name;
                ucp.ShirtNumber = item.shirt_number;
                ucp.Position = item.position;
                ucp.Capitan = item.captain;
                ucp.PlayerImage = MojiResursiPhoto.UnkonwPlayer;
                ucp.MouseClick += selectPlayer_click;
                ucp.MouseDown += flpFavoritePlayers_MouseDown;
                ucp.MouseDoubleClick += choosePicture_click;
                flpAllPlayers.Controls.Add(ucp);

            }

        }

        private void flpFavoritePlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPlayer.DoDragDrop(selectedPlayer, DragDropEffects.Move);

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
                selectedPlayer.PlayerImage = new Bitmap(ofd.FileName);


            }
        }

        private void selectPlayer_click(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                selectedPlayer = (UCPlayer)sender;

                if (selectedPlayer.BackColor == Color.Yellow)
                {
                    selectedPlayer.BackColor = Color.Empty;
                    selectedUCPlayers.Remove(selectedPlayer);
                }

                else
                {
                    selectedPlayer.BackColor = Color.Yellow;
                }
            }
            if (!selectedUCPlayers.Contains(selectedPlayer) && selectedPlayer.BackColor == Color.Yellow)
            {
                selectedUCPlayers.Add(selectedPlayer);
            }
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Statistika stat = new Statistika();
            stat.Show();
            this.Close();
        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {

            if (flpFavoritePlayers.Controls.Count < 3 && selectedUCPlayers.Count <= 3)
            {
                foreach (var player in selectedUCPlayers)
                {
                    player.BackColor = Color.Empty;
                    player.IconFavoritePlayer = MojiResursiPhoto.Star;
                    flpFavoritePlayers.Controls.Add(player);
                }
            }
            else
            {
                MessageBox.Show("Maximalni broj igraca je 3");
            }

        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            UCPlayer player = sender as UCPlayer;
            e.Effect = DragDropEffects.Move;
        }

        private void btn_Clear_click(object sender, EventArgs e)
        {
            flpFavoritePlayers.Controls.Clear();

            if (selectedUCPlayers.Count != 0)
            {
                foreach (var player in selectedUCPlayers)
                {
                    player.IconFavoritePlayer = null;
                    player.BackColor = Color.Empty;
                    flpAllPlayers.Controls.Add(player);
                }
            }
            selectedUCPlayers.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedUCPlayers.Count == 0)
            {
                MessageBox.Show("prazno");
            }
            else
            {
                MessageBox.Show(selectedUCPlayers.Count.ToString());
            }
        }
    }
}
