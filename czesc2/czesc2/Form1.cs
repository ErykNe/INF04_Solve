using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace czesc2
{
    public partial class Form1 : Form
    {
        public string Numer, Imie, Nazwisko, KolorOczu;
    
        public Form1()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            KolorOczu = "niebieskie";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            KolorOczu = "zielone";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            KolorOczu = "piwne";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Numer = textBox1.Text;
            Regex regex = new Regex("^[0-9]+$");
            if (!(regex.Match(this.Numer).Success) && this.Numer.Length > 0)
            {
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.Show("Uwaga: nieprawidłowe dane wejściowe", textBox1, textBox1.Width, 0, 1000);
            }
            ShowProperImage();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.Imie = textBox2.Text;
            Regex regex2 = new Regex("^[A-Za-z]+$");
            if (!(regex2.Match(this.Imie).Success) && this.Imie.Length > 0)
            {
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.Show("Uwaga: nieprawidłowe dane wejściowe", textBox2, textBox2.Width, 0, 1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Imie) &&
                !string.IsNullOrWhiteSpace(Nazwisko))
            {
                MessageBox.Show(this.Imie + " " + this.Nazwisko + " kolor oczu " + this.KolorOczu, "Dane", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wprowadź dane","Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.Nazwisko = textBox3.Text;
            Regex regex3 = new Regex("^[A-Za-z]+$");
            if (!(regex3.Match(this.Nazwisko).Success) && this.Nazwisko.Length > 0)
            {
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.Show("Uwaga: nieprawidłowe dane wejściowe", textBox3, textBox3.Width, 0, 1000);
            }
        }
        /*
        ********************************************
        nazwa funkcji: ShowProperImage
        opis funkcji: Nadaje Ścieżkę do obrazków do PictureBoxa w zależności od wartości zmiennej Number
        parametry: brak
        zwracany typ i opis: brak
        autor: Eryk Ne (numer zdającego)
        */
        private void ShowProperImage()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "assets\\" + this.Numer + "-zdjecie.jpg");
                pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "assets\\" + this.Numer + "-odcisk.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }

        }
    }
}
