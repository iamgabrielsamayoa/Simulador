using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clase04_04
{
    public partial class Bt50Inside : Form
    {
        public Bt50Inside()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)//Buy it now: Redirecciona al sitio web para comprar el vehiculo
        {
            Process.Start("https://mazdaguatemala.com/vehiculos/mazda-bt50/");
        }
    }
}
