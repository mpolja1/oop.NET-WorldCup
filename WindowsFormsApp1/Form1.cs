using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            //    ofd.InitialDirectory = Application.StartupPath;
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        // display image in picture box  
            //        pictureBox1.Image = new Bitmap(ofd.FileName);
            //        // image file path  

            //}
            string ime = "DanijeeSubasic";
            pictureBox1.Image = DohvatiSliku(ime);
          
        }

        private Image DohvatiSliku(string ime)
        {
            ResourceManager MyResourceClass =
  new ResourceManager(typeof(MojiResursi));

            ResourceSet resourceSet =
                MyResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                //MessageBox.Show(resourceKey);
                if (resourceKey == ime)
                {
                    return  (Image)entry.Value;
                   
                }
                
            }
            return MojiResursi.AndrejKramaric;
        }
      
    }


    }
    

