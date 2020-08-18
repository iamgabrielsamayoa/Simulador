using clase04_04.Clases;
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

namespace clase04_04
{
    public partial class main1 : Form
    {
        string[] canciones;
        public main1()
        {
            InitializeComponent();
            canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Main", "*.mp4"); //Reproducimos el video de encendido
            axWindowsMediaPlayer1.URL = canciones[0];//Video Mazda al iniciar
            axWindowsMediaPlayer2.URL = canciones[2];//Video Honda al iniciar
            axWindowsMediaPlayer3.URL = canciones[1];//Video Kawasaki al iniciar
        }

        private void button1_Click_1(object sender, EventArgs e)//BT-50
        {
            PickUp WindowsPk = new PickUp();
            WindowsPk.Show();
        }
        
        private void button3_Click_1(object sender, EventArgs e)//Honda Civic
        {
            Sedan windowsd = new Sedan();
            windowsd.Show();
        }

       
        private void button2_Click(object sender, EventArgs e)//Kawasaki
        {
            Moto windowmt = new Moto();
            windowmt.Show();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            clsPickUp pk = new clsPickUp("Mazda BT 50 PRO", "Orange", 2020);
            MessageBox.Show(pk.GetDatos());
        }

        private void axWindowsMediaPlayer3_Enter(object sender, EventArgs e)
        {
            clsSedan Sd = new clsSedan("Honda Civic Type R", "Blanco", 2020);
            MessageBox.Show(Sd.GetDatos());
        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {
            clsMoto Mt = new clsMoto("Kawasaki Z900", "Black", 2020);
            MessageBox.Show(Mt.GetDatos());
        }
    }
}
