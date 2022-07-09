using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class Statistika : Form
    {
        IRepo repo = new ApiRepoMen();
        IFile _repoFile;
        List<Match> mecevi;
        List<Player> statisticsPlayers;
        string country;

        public Statistika()
        {
            InitializeComponent();
            try
            {
                _repoFile = RepoFactory.GetFileRepository();
                country = _repoFile.LoadFavoriteTeam();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private async void Statistika_Load(object sender, EventArgs e)
        {
            try
            {

                mecevi = await repo.GetMatchesByCountry(country);
                statisticsPlayers = await LoadStatisticsPlayer();
                AddStatsToFlp();
                AddMatchesToFlp();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private async Task<List<Player>> LoadStatisticsPlayer()
        {
            List<Player> playerList = new List<Player>();
            HashSet<Player> players = await repo.GetPlayers(country);
            List<Event> events = await repo.GetAllEvents(country, mecevi);
            foreach (var igrac in players)
            {
                foreach (var eventt in events)
                {
                    if (eventt.type_of_event == "goal" || eventt.type_of_event == "goal-penalty")
                    {
                        if (igrac.name == eventt.player)
                        {
                            igrac.BrojGolova++;
                        }
                    }
                    if (eventt.type_of_event == "yellow-card")
                    {
                        if (igrac.name == eventt.player)
                        {
                            igrac.BrojZutihKartona++;
                        }
                    }
                }
                playerList.Add(igrac);
            }
            return await Task.Run(() => playerList);
        }

        private void AddStatsToFlp()
        {
            flwPlayerStats.Controls.Clear();
            foreach (var igrac in statisticsPlayers)
            {
                UCPlayerStats ucp = new UCPlayerStats();
                ucp.FullName = igrac.name;
                ucp.Goals = igrac.BrojGolova;
                ucp.YellowCards = igrac.BrojZutihKartona;
                ucp.PlayerPhoto = GetPhoto(igrac.name);
                flwPlayerStats.Controls.Add(ucp);
            }

        }

        private Image GetPhoto(string name)
        {
            ResourceManager MyResourceClass =
                        new ResourceManager(typeof(MojiResursiPhoto));
            name = name.Replace(" ", "").ToLower();
            name = name.Replace("-", "_").ToLower();
            ResourceSet resourceSet =
                MyResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                //MessageBox.Show(resourceKey);
                if (resourceKey.ToLower() == name)
                {
                    return (Image)entry.Value;

                }

            }
            return MojiResursiPhoto.UnkonwPlayer;
        }


        private void AddMatchesToFlp()
        {
            flwAttendence.Controls.Clear();
            List<Match> matches = mecevi;

            foreach (var mec in mecevi)
            {
                UCMatchStats ms = new UCMatchStats();
                ms.Locationn = mec.location;
                ms.Attendance = mec.attendance;
                ms.HomeTeam = mec.home_team_country;
                ms.AwayTeam = mec.away_team_country;

                flwAttendence.Controls.Add(ms);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mecevi.Sort();
            AddMatchesToFlp();
        }

        private void bntCards_Click(object sender, EventArgs e)
        {
            statisticsPlayers.Sort((x, y) => -x.BrojZutihKartona.CompareTo(y.BrojZutihKartona));
            AddStatsToFlp();
        }

        private void btnGoals_Click(object sender, EventArgs e)
        {
            statisticsPlayers.Sort((x, y) => -x.BrojGolova.CompareTo(y.BrojGolova));
            AddStatsToFlp();
        }
       
        private void Statistika_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(Properties.Resources.Exit, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.FormClosing -= Statistika_FormClosing;
                Application.Exit();
             
            }
            else
            {
                e.Cancel = true;
            }

        }
        private void bntPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialogPlayers.Show();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Point point = new Point(0, 0);
            int i = 1;

            foreach (UCPlayerStats player in flwPlayerStats.Controls)
            {
                if (i % 8 == 0)
                {
                    point.X += player.Width + 15;
                    point.Y = 0;

                }


                Bitmap bitmap = new Bitmap(player.Size.Width, player.Size.Height);
                player.DrawToBitmap(bitmap, new Rectangle
                {
                    Width = player.Size.Width,
                    Height = player.Size.Height
                });
                e.Graphics.DrawImage(bitmap, point);
                
                i++;
                point.Y += player.Height + 10;
            }
            


        }

        private void bntPrintMatches_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialogMatches.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void printDocumentMatches_PrintPage(object sender, PrintPageEventArgs e)
        {
            Point point = new Point(0, 0);
            foreach (UCMatchStats match in flwAttendence.Controls)
            {
                Bitmap bitmap = new Bitmap(match.Size.Width, match.Size.Height);
                match.DrawToBitmap(bitmap, new Rectangle
                {
                    Width = match.Size.Width,
                    Height = match.Size.Height
                });
                e.Graphics.DrawImage(bitmap,point);
                point.Y += match.Height + 10;
            }

        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Postavke postavke = new Postavke();
            postavke.Show();
            this.FormClosing -= Statistika_FormClosing;
            this.Close();
        }
    }
}
