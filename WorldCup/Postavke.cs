using DataAccessLayer;
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
       
        FileRepo repo = new FileRepo();
        
        public Postavke()
        {
            InitializeComponent();
        }

        private void Postavke_Load(object sender, EventArgs e)
        {

            try
            {
              List<string> postavke = FileRepo.LoadPostavke();
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
               
                repo.SavePostavke(selectedJezik, selectedPrvenstvo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Zelite li spremiti postavke", "Potvrda", MessageBoxButtons.OKCancel);

            if (result== DialogResult.OK)
            {
                string selectedJezik = cbJezik.SelectedItem.ToString();
                string selectedPrvenstvo = cbPrvenstvo.SelectedItem.ToString();

                try
                {

                    repo.SavePostavke(selectedJezik, selectedPrvenstvo);
                    MessageBox.Show("Upjesno spremljene postavke");
                    
                    Form form = new OdabirTima();
                    form.Show();
                    
                
                    
                }
                catch (Exception em)
                {

                    MessageBox.Show(em.Message);
                }

                
            }
            else
            {
                MessageBox.Show("Odustali ste");
            }

          
        }
    }
}
