using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
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
            //Application.Run(new Postavke());

            try
            {
                IFile fileRepo = RepoFactory.GetFileRepository();
                List<string> postavke = fileRepo.LoadPostavke();

                if (postavke == null)
                {
                    Application.Run(new Postavke());
                }
                else 
                {
                    Application.Run(new OdabirTima());
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
