using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ejemploPooCarro.clases;

namespace clase04_04.Clases
{
    class clsMoto : clsCarroBase //: representa que se hereda de clsCarroBase
    {
        //Agregamos Propiedades
        protected bool SealedChain = false; //Cadena que no requiere mantenimiento
        protected string[] DrivingModes = new string[] { "Rain","Road","Sport", "Rider" } ;
        protected bool FullPower = false;/*La moto cuenta con un modo fullPower denominado por el 
                                           fabricante el cual se activa luego de cierta velocidad*/

        //Luego Utilizamos el Constructor 
        public clsMoto(string marcaCarro, string ColorCarro, int yearCreate) : base(marcaCarro, ColorCarro, yearCreate)
        {
            marca = marcaCarro;
            Color = ColorCarro;
            añoCreación = yearCreate;
            VelocidadMaxima = 260;
            CajaVelMaxima = 5;
            CajaManual = true;
            HP = 125;
            Combustible = "Premium";
            SealedChain = true;
        }
        //Metodos
        public void ActivarFullPower()
        {
            if (velocidad > 160)
            {
                FullPower = true;
                MessageBox.Show("Full Power Activated");
            }
            if (velocidad < 150)
            {
                FullPower = false;
            }
        }
    }
}
