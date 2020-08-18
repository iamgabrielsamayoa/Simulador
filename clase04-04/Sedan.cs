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
    public partial class Sedan : Form
    {
        bool brake = false;//No deja repetir el mismo video durante el freno
        bool accel = false;//No deja repetir el mismo video durante aceleracion
        string[] canciones;//Nos sirve para controlar la musica
        bool CarOn = false; //Esta variable nos sirve de control para reproducir o no los sonidos del vehiculo
        bool TurnRadioOn = false;//Indica que el radio esta encendido
        clsObjetoRandom Song = new clsObjetoRandom();//Clase Aleatoria
        clsSedan Sd = new clsSedan("Honda Civic Type R","Blanco",2020);//Instanciamos
        public Sedan()
        {
            InitializeComponent();
            //Reproducimos un videos justo al iniciar el form
            canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Civic", "*.mp4"); //Reproducimos el video de encendido
            axWindowsMediaPlayer2.URL = canciones[2];
        }

        private void pictureBox2_Click(object sender, EventArgs e)//Turn On Engine
        {
            Sd.encenderCarro();
            label1.Text = Sd.obtenerVelocidad() + "Km/h" ;
            label2.Text = Sd.obtenerNumVelocidad() + "";
            
            if (CarOn == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Civic", "*.mp4"); //Reproducimos el video de encendido
                axWindowsMediaPlayer2.URL = canciones[1];
                CarOn = true;
            }
            else if (CarOn == true)
            {
                CarOn = false;//Nos asegura que no reproduzca el video cuando se apague
                axWindowsMediaPlayer2.close();//Detiene el reproductor si apaga el carro
            }
        }

        private void button9_Click(object sender, EventArgs e)//Play Music
        {
            if (TurnRadioOn == true)
            {
                canciones = Directory.GetFiles("c:\\musica\\", "*.mp3");
                axWindowsMediaPlayer1.URL = canciones[Song.GeneraNum()];
            }
            else if (TurnRadioOn == false)
            { MessageBox.Show("Debe encender el radio"); }
        }

        private void button6_Click(object sender, EventArgs e)//Turn on Radio
        {
            if (TurnRadioOn == false)
            {
                TurnRadioOn = true;
            }
            else
            {
                TurnRadioOn = false;
                axWindowsMediaPlayer1.close();
                MessageBox.Show("Ha Apagado el Radio");
                
            }
        }

        private void button7_Click(object sender, EventArgs e)//Hand Brake
        {
            Sd.frenarMano();
            label1.Text = Sd.obtenerVelocidad() + "Kms / h";
            label3.Text = Sd.ObtenerModoManejo() + "";
            if (brake == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\civic", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[4];
                brake = true;
                accel = false;
            }
            label1.Text = Sd.obtenerVelocidad() + "Kms / h";
        }

        private void button2_Click(object sender, EventArgs e)//Brake
        {
            Sd.frenar();
            label1.Text = Sd.obtenerVelocidad() + "Kms / h";
            if (brake == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\civic", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[4];
                brake = true;
                Sd.frenar();
                accel = false;
            }
            label1.Text = Sd.obtenerVelocidad() + "Kms / h";
            label3.Text = Sd.ObtenerModoManejo() + "";
        }

        private void button1_Click(object sender, EventArgs e)//Speed Up
        {
            Sd.acelerar(); //Acelera += 10 mientras que alcanza la velocidad maxima
            //Sd.ElejirModo();//Activa el modo sport si rebasa 150km/h
            label1.Text = Sd.obtenerVelocidad() + "Kms / h";//Muestra el valor en la etiqueta
            label2.Text = Sd.obtenerNumVelocidad() + "";
            label3.Text = Sd.ObtenerModoManejo() + "";//Actualiza la etiqueta en que modo se conduce
            if (CarOn == true && accel == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\civic", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[3];
                accel = true;
                brake = false;//esto nos asegura que el video de freno se reproduzca si ya habiamos frenado una vez
            }
           
        }

        private void button3_Click(object sender, EventArgs e)//Subir Vel
        {
            Sd.Subirvelocidad();
            label2.Text = Sd.obtenerNumVelocidad() + "";
        }

        private void button5_Click(object sender, EventArgs e)//bajar Vel
        {
            Sd.Bajarvelocidad();
            label2.Text = Sd.obtenerNumVelocidad() + "";
        }

        private void button8_Click(object sender, EventArgs e)//Muestra la galeria
        {
            CivicInside windowscivic = new CivicInside();
            windowscivic.Show();
        }
    }
}
