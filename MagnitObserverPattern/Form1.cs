using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagnitObserverPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }
        Magnit magnit;
        Graphics g;
        public int X = 0;
        public int Y = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            magnit = new Magnit(pictureBox1, 400, g);
            for (int i = 1; i < 13; i++)
            {
                magnit.metals.Add(new Iron((PictureBox)this.Controls.Find($"Iron{i}", true)[0], 5));
            }
            for (int i = 1; i < 6; i++)
            {
              magnit.metals.Add(new NoIron((PictureBox)this.Controls.Find($"NoIron{i}", true)[0], 0));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            g.Clear(Color.WhiteSmoke);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            magnit.move(new Point(X, Y));  
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X-pictureBox1.Width / 2;
            Y = e.Y-pictureBox1.Height / 2;
        }
    }
}
