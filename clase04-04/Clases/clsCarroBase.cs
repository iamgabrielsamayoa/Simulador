using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemploPooCarro.clases
{
    class clsCarroBase //Definicion o nombre de la clase
    {
        protected String marca = "";//Propiedades //Protected permite acceder a la clase padre e hijo
        protected String Color = "";
        protected string CCMotor = "";
        protected int añoCreación = 1900;
        protected int VelocidadMaxima = 300;
        protected int velocidad = 0;//control de velocidad
        protected bool encendido = false;//Encender el Vehiculo
        protected int NumAsientos = 0;
        protected bool CajaManual = false;//Dependiendo de su valor pedira cambios o no
        protected bool CajaAutomatica = false;
        protected int CajaVelocidades = 1;
        protected int CajaVelMaxima = 0;
        protected string Combustible = "";//Tipo de Gasolina
        protected int HP = 0;//Caballos de Fuerza del Vehiculo
        protected bool CamRetroceso = false;

        public clsCarroBase(String marcaCarro, String ColorCarro, int yearCreate)//Constructor
        {
            marca = marcaCarro;
            Color = ColorCarro;
            añoCreación = yearCreate;
        }

  
        public void acelerar()
        {
            velocidad += 10;
            if (encendido == false) 
            {
                MessageBox.Show("Debe encender el carro primero");
                velocidad -= 10;
            }//No nos permite acelerar sin que encendamos el carro

            if (CajaManual == true)
            {
                if (velocidad == 40)
                {
                    MessageBox.Show("Por favor cambie a 2nda velocidad");
                    CajaVelocidades++;
              }
                if (velocidad == 70)
                {
                    MessageBox.Show("Por favor cambie a 3ra velocidad");
                    CajaVelocidades++;
                }
                if (velocidad == 90)
                {
                    MessageBox.Show("Por favor cambie a 4ta velocidad");
                    CajaVelocidades++;
                }
                if (velocidad == 140)
                {
                    MessageBox.Show("Por favor cambie a 5ta velocidad");
                    CajaVelocidades++;
                }
            }//Pide Cambios Manualmente
            if (CajaAutomatica == true)
            {
                if (velocidad == 40)
                {
                   CajaVelocidades++;
                }
                if (velocidad == 70)
                {
                    CajaVelocidades++;
                }
                if (velocidad == 90)
                {
                    CajaVelocidades++;
                }
                if (velocidad == 140)
                {
                   CajaVelocidades++;
                }
            }//Hace cambios Automaticamente

            if (velocidad > VelocidadMaxima)
            {
                MessageBox.Show("Ha alcanzado el limite de velocidad");
                velocidad -= 10;
            }//Este If nos permite asegurar que el vehiculo no rebase su velocidad Max

        }

        public void encenderCarro()
        {
            if (encendido == true)
            {
                encendido = false;
                MessageBox.Show("El Vehiculo ya estaba encendido, lo ha apagado");
            }//Apaga el Carro si ya habiamos presionado una vez
            else
            { encendido = true; }//Enciende El Carro
        }
       
        public void ElegirCajaM()//Elegir manualmente la caja esto funciona en carros tip Tronic como el Honda Civic
        {
            if (encendido == false)
            {
                MessageBox.Show("Debe encender el carro primero");
            }//Este If no deja activarlo sin encender el carro
            CajaManual = true;
            CajaAutomatica = false;
        }
        public void ElegirCajaA()
        {
            if (encendido == false)
            {
                MessageBox.Show("Debe encender el carro primero");
            }
            CajaAutomatica = true;
            CajaManual = false;
        }//Elegir manualmente la caja esto funciona en carros tip Tronic como el Honda Civic
        public int obtenerVelocidad()
        {
            return velocidad;
        }
        public int obtenerNumVelocidad()
        {
            return CajaVelocidades;
        }//Actualiza la caja de velocidades

        public void frenar()
        {
           if (velocidad > 0)
            {
                velocidad -= 10;
            }//Dismuye velocidad de 10 en 10
            if (CajaManual == true || CajaAutomatica == true)//Este If nos disminuira un cambio al bajar la velocidad
            {
                if (velocidad < 40)
                {
                    CajaVelocidades--;
                }
                if (velocidad < 70)
                {
                    
                    CajaVelocidades--;
                }
                if (velocidad < 90)
                {
                   CajaVelocidades--;
                }
                if (velocidad < 140)
                {
                    CajaVelocidades--;
                }
            }
            else if (velocidad == 0) {
                CajaVelocidades = 1;
                MessageBox.Show("Su velocidad ya es de 0");
            }//Si la velocidad es 0 nos muestra el mensaje
        }//Disminuye de 10 similar a el freno real
        public void frenarMano()
        {
            velocidad = 0;
            CajaVelocidades = 1;
        }//Disminuye la velocidad a 0
        public void Subirvelocidad()
        {
            
            CajaVelocidades++;
            if (CajaVelocidades == CajaVelMaxima)
            {
                MessageBox.Show("La transmision alcanzo la velocidad maxima");
                CajaVelocidades--;
            }
        }//aumenta la caja de cambios
        public void Bajarvelocidad()
        {
            
            CajaVelocidades--;
        }//Resta la caja de cambios
        public void EncenderCamRetroceso()//Enciende o Apaga la camara de Reversa si la velocidad es o sube de 0
        {
            if (velocidad == 0 && CamRetroceso == false) 
            { 
                CamRetroceso = true;
            }
            if (velocidad > 0 && CamRetroceso == true)
            {
                CamRetroceso = false;
            }
        }

        public String GetDatos() //nos muestra la concatenacion con los datos del vehiculo
        {
            String datosCarro = "Brand = " + marca + "\nMax Speed ="+ VelocidadMaxima+ "\nColor = " + Color + "\nYear of Manufacture = " + añoCreación + "\nFuel = " + Combustible + "\nHorse Power = " + HP;
            return datosCarro;
        }

    }
}

   

