﻿using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        HashSet<Player> playerList;
        List<Player> favoritePlayers;

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
                favoritePlayers = _fileRepo.LoadFavoritePlayers();
                FillAsyncPlayers(country);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private async void FillAsyncPlayers(string country)
        {
            playerList = await _repo.GetPlayers(country);

            foreach (var player in playerList)
            {
                UCPlayer ucp = new UCPlayer(player);
                ucp.PlayerImage = MojiResursiPhoto.UnkonwPlayer;
                ucp.MouseClick += selectPlayer_click;
                ucp.MouseDown += flpFavoritePlayers_MouseDown;
                ucp.MouseDoubleClick += choosePicture_click;
                flpAllPlayers.Controls.Add(ucp);

            }
            if (favoritePlayers.Count !=0)
            {
                foreach (var player in favoritePlayers)
                {
                    UCPlayer uCPlayer = new UCPlayer(player);
                    flpFavoritePlayers.Controls.Add(uCPlayer);
                }
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

                MessageBox.Show(Path.GetFullPath(ofd.FileName));
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
                MessageBox.Show(Properties.Resources.MaxIgraca);
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
        public List<Player> ParseUCToPlayers()
        {
            List<Player> list = new List<Player>();
            foreach (UCPlayer player in flpFavoritePlayers.Controls)
            {
                list.Add(player.ParseFrameToPlayer(player));
            }
            return list;
        }
        private void OmiljeniIgraci_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _fileRepo.SaveFavoritePlayers(ParseUCToPlayers());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
