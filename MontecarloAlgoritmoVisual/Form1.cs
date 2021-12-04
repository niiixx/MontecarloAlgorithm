using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MontecarloAlgoritmoVisual
{
    public partial class FormPrincipal : Form
    {
        public static double ballsGlobal = 1000;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics(); // Create circle
            g.DrawRectangle(new Pen(Color.Black, 3), 50, 50, 300, 300);
            g.DrawEllipse(new Pen(Color.Red, 3), 50, 50, 300, 300);
            button2.Show();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Equals(""))
            {
                ballsGlobal = Int32.Parse(textBox1.Text);
            }

            button1.Hide();
            button2.Hide();
            textBox1.Hide();
            label7.Hide();
            label9.Text = ballsGlobal.ToString();
            double dotsin = 0; // dots in 
            int dotsout = 0; // dots out
            double pi = 0; // PI estimated
            int x = 0; // Coordinate x
            int y = 0; // Coordinate y

            Random r = new Random(); 
            Pen p1; // Points
            Graphics g2 = CreateGraphics();

            for(int i = 0; i < ballsGlobal; i++)
            {
                // Random dot (x,y) between boundaries
                x = r.Next(50, 351);
                y = r.Next(50, 351);

                // Center of circle is at (250,220)

                int radius = (int)(Math.Sqrt(Math.Pow(x - 200, 2) + Math.Pow(y - 200, 2)));

                if (radius <= 150)
                { // Dot in
                    p1 = new Pen(Color.Green);
                    dotsin++;
                }
                else
                { // Dot out
                    p1 = new Pen(Color.Orange);
                    dotsout++;
                }

                g2.DrawRectangle(p1, x, y, 1, 1);
            }

            pi = (4* dotsin) / ballsGlobal;
            Console.WriteLine(pi);

            label4.Text = dotsout.ToString();
            label5.Text = dotsin.ToString();
            label6.Text = pi.ToString();

        }

    }
}
