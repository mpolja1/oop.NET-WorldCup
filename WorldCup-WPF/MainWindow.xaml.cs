using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
using DataAccessLayer.Models;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string resolution;
        private IFile _fileRepo;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _fileRepo = RepoFactory.GetFileRepository();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

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
                    Application.Current.MainWindow.Width = 700;
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
                    Application.Current.MainWindow.Width = 500;
                    Application.Current.MainWindow.Height = 500;
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

        private void btnPocetnePostave_click(object sender, RoutedEventArgs e)
        {
            //Main.Content = new Postave();
        }


        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Zelite li izaci iz aplikacije", "Potvrda", MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();

            }
        }
    }
}