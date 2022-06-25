using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class Postavke : Form
    {

        IFile _repoFile;
        
        public Postavke()
        {
            InitializeComponent();
        }

        private void Postavke_Load(object sender, EventArgs e)
        {

            try
            {
                _repoFile = RepoFactory.GetFileRepository();
              List<string> postavke = _repoFile.LoadPostavke();
                cbJezik.SelectedIndex = 0;
                cbPrvenstvo.SelectedIndex = 0;
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        

        private void Postavke_FormClosing(object sender, FormClosingEventArgs e)
        {
            string selectedJezik = cbJezik.SelectedItem.ToString();
            string selectedPrvenstvo = cbPrvenstvo.SelectedItem.ToString();
            
            try
            {
               
                _repoFile.SavePostavke(selectedJezik, selectedPrvenstvo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Properties.Resources.SpremanjePostavki, Properties.Resources.Potvrda, MessageBoxButtons.OKCancel);

            if (result== DialogResult.OK)
            {
                string selectedJezik = cbJezik.SelectedItem.ToString();
                string selectedPrvenstvo = cbPrvenstvo.SelectedItem.ToString();

                try
                {

                    _repoFile.SavePostavke(selectedJezik, selectedPrvenstvo);
                    MessageBox.Show(Properties.Resources.Uspjesno);

                    this.Hide();  
                    OdabirTima form = new OdabirTima();


                    form.Closed += (s, args) => this.Close();
                    form.Show();



                }
                catch (Exception em)
                {

                    MessageBox.Show(em.Message);
                }

                
            }
            

          
        }
    }
}
