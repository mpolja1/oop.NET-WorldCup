using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorldCup_WPF
{
    /// <summary>
    /// Interaction logic for Postavke.xaml
    /// </summary>
    /// 
    
    public partial class Postavke : Page
    {
       private IFile _fileRepo = RepoFactory.GetFileRepository();
       
        
        public Postavke()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string resolution = cbRezolucija.Text;
            string language = cbJezik.Text;
            string tournament = cbPrvenstvo.Text;

            if (MessageBox.Show("Do you want do save settings",
                     "Save settings",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _fileRepo.SaveResolution(resolution);
                _fileRepo.SavePostavke(language, tournament);
                MessageBox.Show("Restart app");
                
            }
            
        }
    }
}
