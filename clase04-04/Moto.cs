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
    public partial class Moto : Form
    {
        string[] canciones;
        bool brake = false; //Esta variable nos permite reproducir solamente una vez el video de freno aunque hagamos click varias veces
        bool accel = false; //Esta variable controla que el video de acelerar se reproduzca una vez aunque aceleremos varias veces
        bool CarOn = false; //Esta variable nos sirve de control para reproducir o no los sonidos del vehiculo
        bool TurnRadioOn = false;
        clsObjetoRandom Song = new clsObjetoRandom();//Instanciamos Clase random
        clsMoto Mt = new clsMoto("Kawasaki Z900", "Black", 2020);//Agregamos los datos al Constructor
        public Moto()
        {
            InitializeComponent();
            canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Main", "*.mp4"); //Reproducimos el video de encendido
            axWindowsMediaPlayer2.URL = canciones[2];
        }

        private void button4_Click(object sender, EventArgs e)//Bajara Velocidad con 
        {
            
            if (brake == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Videos Kawasaki Z900", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[1];
                accel = true;
                Mt.Bajarvelocidad();
                label2.Text = Mt.obtenerNumVelocidad() + "";
            }
            else
            {
                Mt.Bajarvelocidad();
                label2.Text = "N";

            }

        }

        private void button1_Click(object sender, EventArgs e)//Acelerar
        {
            if (CarOn == true && accel == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Videos Kawasaki Z900", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[2];
                accel = true;
                Mt.ActivarFullPower();
            }
            else
            {
                Mt.acelerar(); //Acelera += 10 mientras que alcanza la velocidad maxima
                label1.Text = Mt.obtenerVelocidad() + "Kms / h";//Muestra el valor en la etiqueta
                label2.Text = Mt.obtenerNumVelocidad() + "";//obtiene que velocidad va la caja de cambios
            }
        }

        private void button2_Click(object sender, EventArgs e)//Brake
        {
            if (brake == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Videos Kawasaki Z900", "*.mp4"); //Reproducimos el video de acelerar
                axWindowsMediaPlayer2.URL = canciones[1];
                brake = true;
                Mt.frenar();
                accel = false;
            }
            else
            {
                Mt.frenar();
                
            }
           
            label1.Text = Mt.obtenerVelocidad() + "Kms / h";
            label2.Text = "N";
        }

        private void button8_Click(object sender, EventArgs e)//Front Wheel Brake
        {
            Mt.frenarMano();
            label1.Text = Mt.obtenerVelocidad()+"Kms / h";
        }

        private void button3_Click(object sender, EventArgs e)//Subir Velocidad
        {
            Mt.Subirvelocidad();
            label2.Text = Mt.obtenerNumVelocidad() + "";
        }

        private void button5_Click(object sender, EventArgs e)//Turn On Airpods
        {
            if (TurnRadioOn == false)
            {
                TurnRadioOn = true;
            }
            else
            {
                TurnRadioOn = false;
                axWindowsMediaPlayer1.close();
                MessageBox.Show("Ha Apagado sus Airpods");

            }
        }

        private void button6_Click(object sender, EventArgs e)//Play Music
        {
            if (TurnRadioOn == true)
            {
                canciones = Directory.GetFiles("c:\\musica\\", "*.mp3");
                axWindowsMediaPlayer1.URL = canciones[Song.GeneraNum()];
            }
            else if (TurnRadioOn == false)
            { MessageBox.Show("Debe encender el radio"); }
        }

        private void pictureBox4_Click(object sender, EventArgs e)//Turn On Engine 
        {
                Mt.encenderCarro();//Encendemos el Carro
            if (CarOn == false)
            {
                canciones = Directory.GetFiles("C:\\Users\\qwertyuiasdfghj\\Downloads\\Fotos Progra 1\\Videos Kawasaki Z900", "*.mp4"); //Reproducimos el video de encendido
                axWindowsMediaPlayer2.URL = canciones[0];
                CarOn = true;
            }
              else if (CarOn == true)
            {
                CarOn = false;
                axWindowsMediaPlayer2.close();//Detiene el reproductor si apaga el carro
            }  

        }

        private void pictureBox2_Click(object sender, EventArgs e)//Show data
        {
           MessageBox.Show( Mt.GetDatos());
            
        }

        private void button7_Click(object sender, EventArgs e)//Muestra la galeria
        {
            KawasakiGallery windowka = new KawasakiGallery();
            windowka.Show();
        }
    }
}
