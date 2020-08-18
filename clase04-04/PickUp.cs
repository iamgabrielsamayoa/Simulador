using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ejemploPooCarro;
using ejemploPooCarro.clases;
using System.IO;
using clase04_04.Clases;


namespace clase04_04
{
    public partial class PickUp : Form
    {
        string[] canciones;
        bool brake = false;//Nos permite reproducir video sin pausar mientras frenamos
        bool accel = false;//Nos permite reproducir video sin pausar mientras aceleramos
        bool CarOn = false; //Esta variable nos sirve de control para reproducir o no los sonidos del vehiculo
        bool TurnRadioOn = false;//Nos ayuda a apagar el radio si ya estaba encendido
        clsObjetoRandom Song = new clsObjetoRandom();
        clsPickUp pk = new clsPickUp("Mazda BT-50", "Orange", 2020);//Instanciamos un nuevo objeto Pick Up
        public PickUp()
        {
            InitializeComponent();
            canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Mazda", "*.mp4"); //Reproducimos el video de acelerar
            axWindowsMediaPlayer2.URL = canciones[1];
        }
        
        private void button2_Click(object sender, EventArgs e) //Acelerar
        {
           pk.acelerar(); //Acelera += 10 mientras que alcanza la velocidad maxima
           label1.Text = pk.obtenerVelocidad() + "Kms / h";//Muestra el valor en la etiqueta
           label4.Text = pk.obtenerVelocidad() + "Kms / h";
            label2.Text = pk.obtenerNumVelocidad() + "";
            if (CarOn == true && accel == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Mazda", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[2];
                accel = true;
                brake = false;//esto nos asegura que el video de freno se reproduzca si ya habiamos frenado una vez
            }
        }

        private void button3_Click(object sender, EventArgs e) //Freno
        {
            pk.frenar();//Detiene el vehiculo
            label2.Text = "P";//Actualiza la caja de cambios
            label1.Text = pk.obtenerVelocidad() + "Kms / h"; //Muestra la velocidad en la etiqueta1
            if (brake == false)//Este If if nos permite la reproducción propia del video de frenar sin multiples reproducciones al presionar el freno mas de una vez
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Mazda", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[3];
                brake = true;
                accel = false;
            }

        }

        private void button8_Click(object sender, EventArgs e) //Caja M
        {
            pk.ElegirCajaM();//elegimos caja Manual nos pedira cambios
            label3.Text = "M";
        }

        private void button9_Click(object sender, EventArgs e) //Caja Aut
        {
            pk.ElegirCajaA();//Elegimos caja Automatica no nos pedira cambios
            label3.Text = "A";
        }

        private void button4_Click(object sender, EventArgs e) // Subir Vel
        {
            pk.Subirvelocidad();
            label2.Text = pk.obtenerNumVelocidad() + "";
        }

        private void button7_Click(object sender, EventArgs e) //Bajar Vel
        {
            pk.Bajarvelocidad();
            label2.Text = pk.obtenerNumVelocidad() + "";
        }

        private void button6_Click(object sender, EventArgs e)//play music
        {
            if (TurnRadioOn == true)
            {
                canciones = Directory.GetFiles("c:\\musica\\", "*.mp3");
                axWindowsMediaPlayer1.URL = canciones[Song.GeneraNum()];
            }
            else if (TurnRadioOn == false) 
            { MessageBox.Show("Debe encender el radio"); }
        }

        private void button5_Click(object sender, EventArgs e)//encender Radio
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

        private void pictureBox5_Click(object sender, EventArgs e)//Encender el Carro
        {
            pk.encenderCarro();//Encendemos el Carro
            label1.Text = pk.obtenerVelocidad() + "Km/h";
            

            if (CarOn == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Mazda", "*.mp4"); //Reproducimos el video de encendido
                axWindowsMediaPlayer2.URL = canciones[0];
                CarOn = true;
            }
            else if (CarOn == true)
            {
                CarOn = false;//Nos asegura que no reproduzca el video cuando se apague
                axWindowsMediaPlayer2.close();//Detiene el reproductor si apaga el carro
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)//Mostrar datos del Pick Up
        {
            pk.GetDatos();
            MessageBox.Show(pk.GetDatos());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Freno de Mano, Vel = 0
        {
            pk.frenarMano();
            label1.Text = pk.obtenerVelocidad() + "Kms / h";//Muestra el valor en la etiqueta
            label4.Text = pk.obtenerVelocidad() + "Kms / h";
             if (brake == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Mazda", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[3];
                brake = true;
                accel = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)//Muestra la Galeria
        {
            Bt50Inside windowbt50 = new Bt50Inside();
            windowbt50.Show();
        }

        private void button11_Click(object sender, EventArgs e)//Activa 4x4
        {
            pk.ActivarAwd();
        }

        private void button12_Click(object sender, EventArgs e)//Enciende las Neblineras
        {
            pk.EncenderNeblineras();
        }
    }
}
