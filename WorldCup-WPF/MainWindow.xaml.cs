using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string resolution;
        List<string> settings;
        private IFile _fileRepo;
        public MainWindow()
        {
            
            
            try
            {
                
                _fileRepo = RepoFactory.GetFileRepository();
                settings = _fileRepo.LoadPostavke();
                string language = settings[0];
                if (language == "Hrvatski")
                {
                    SetCulture("hr");
                }
                else
                {
                    SetCulture("en");
                }
                InitializeComponent();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }

        private void SetCulture(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

          
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                resolution = _fileRepo.LoadResolution();
               
               
            }
            catch (Exception)
            {

                Main.Content = new Postavke();
            }
            switch (resolution)
            {
                case "Mala":
                    Application.Current.MainWindow.Width = 800;
                    Application.Current.MainWindow.Height = 615;
                    break;
                case "Srednja":
                    Application.Current.MainWindow.Width = 1100;
                    Application.Current.MainWindow.Height = 980;
                    break;
                case "PunZaslon":
                    WindowState = WindowState.Maximized;
                    break;

                default:
                    Application.Current.MainWindow.Width = 600;
                    Application.Current.MainWindow.Height = 600;
                    break;
            }
        }
        private void btnPostavke_click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Postavke();
        }

        private void btnPregledReprezentacije_click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PregledReprezent();
        }

        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(Properties.Resources.Confirm, Properties.Resources.CaptionConfirm, MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();

            }
        }
    }
}