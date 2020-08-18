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
    public partial class KawasakiGallery : Form
    {
        public KawasakiGallery()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://guatemala.kawasaki-la.com/la-es?gclid=Cj0KCQjw4dr0BRCxARIsAKUNjWRtNgcAgj3dwkY_t603AgO7joFOaqG8eT9SE2KSz73GdkvL-wT7eRQaAre9EALw_wcB");
        }
    }
}
