using ejemploPooCarro.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clase04_04.Clases
{
    class clsSedan:clsCarroBase 
    {
        protected string ModoSport = ""; //Equivale ya sea a modo Eco, Normal o Sport
        protected bool BrakeAssist = true;//Asistente de Freno
        protected bool LEDDRL = true;//Luz De Manejo durante el dia
        

        public clsSedan(string marcaCarro, string ColorCarro, int yearCreate) : base(marcaCarro, ColorCarro, yearCreate)
        {
            marca = marcaCarro;
            Color = ColorCarro;
            añoCreación = yearCreate;
            VelocidadMaxima = 270;
            CajaVelMaxima = 5;
            CajaManual = true;
            HP = 306;
            Combustible = "Premium";
            CamRetroceso = true;
        }

        public string ObtenerModoManejo()//Este nos mostrara el modo de manejo dependiendo la velocidad
        {
            if (velocidad > 150)
            {
                ModoSport = "Sport Mode Activated";
                
            }
            else if (velocidad <= 150)
            {
                ModoSport = "Driving on Eco";
                
            }
            return ModoSport;
        }
    }
}
