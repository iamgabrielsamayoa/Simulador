using ejemploPooCarro.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clase04_04
{
    class clsPickUp : clsCarroBase //Hereda de carrobase
    {
        protected bool Awd = false;
        protected int CDeCargaTn = 2;
        protected bool Neblineras = false;
        

        public clsPickUp(string marcaCarro, string ColorCarro, int yearCreate) : base(marcaCarro, ColorCarro, yearCreate)
        {
            marca = marcaCarro;
            Color = ColorCarro;
            añoCreación = yearCreate;
            VelocidadMaxima = 120;
            CajaVelMaxima = 4;
            CajaAutomatica = true;
            Combustible = "Diesel";
            HP = 200;
        }
        public void ActivarAwd() 
        {
            if (Awd == false) 
            {
                Awd = true;
                MessageBox.Show("You have activated AWD");
            }
            else if (Awd == true)
            {
                Awd = false;
                MessageBox.Show("You have deactivated AWD");
            }
        }
        public void EncenderNeblineras()
        {
            
            if (Neblineras == false)
            {
                Neblineras = true;
                MessageBox.Show("You have activated Fog Lights");
            }
            else if (Neblineras == true)
            {
                Neblineras = false;
                MessageBox.Show("You have deactivated Fog Lights");
            }
        }
        
    }
}
