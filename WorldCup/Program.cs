using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WorldCup
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Postavke());

            //try
            //{
            //    List<string> postavke = FileRepo.LoadPostavke();
            //    string team = FileRepo.LoadFavoriteTeam();
            //    List<Player> players = FileRepo.LoadFavoritePlayer();

            //    if (postavke.Count > 0)
            //    {
            //        Application.Run(new Postavke());
            //    }
            //    else if (!String.IsNullOrEmpty(team))
            //    {
            //        Application.Run(new OdabirTima());
            //    }
            //    else if (players.Count > 0)
            //    {
            //        Application.Run(new OmiljeniIgraci());
            //    }
            //}
            //catch (Exception)
            //{

            //    throw new Exception();
            //}


        }
    }
}
