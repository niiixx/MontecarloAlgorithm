using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MontecarloAlgoritmoVisual
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black, 3), 50, 20, 400, 400);
            g.DrawEllipse(new Pen(Color.Red, 3), 50, 20, 400, 400);
        }
    }
}
