using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeiroSetyLab1
{
    public partial class Form1 : Form
    {
        

        Color[] colors = new Color[] {Color.Brown, Color.Crimson, Color.HotPink, Color.DarkOrange, Color.LimeGreen,
        Color.Red, Color.Green, Color.BurlyWood, Color.Ivory, Color.CadetBlue, Color.Khaki, Color.Fuchsia, Color.MediumBlue,
        Color.DarkViolet, Color.LightBlue, Color.Gainsboro, Color.Magenta, Color.Aquamarine, Color.AliceBlue, Color.Coral,
        Color.Cornsilk};

        public Form1()
        {
            InitializeComponent();
            
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.LightGreen);
            for (int i = 0; i < 9; i++)
            {
                g.DrawLine(p, new Point((pictureBox1.Width / 10 * (i + 1)), 0), new Point((pictureBox1.Width / 10 * (i + 1)), pictureBox1.Height));
                g.DrawLine(p, new Point(0, (pictureBox1.Height / 10 * (i + 1))), new Point(pictureBox1.Width, (pictureBox1.Height / 10 * (i + 1))));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            smp sm = new smp();
            sm.setRand();
            int X = pictureBox1.Width / 10;
            int Y = pictureBox1.Height / 10;
            int [] k = new int[20];

            sm.T = Convert.ToInt32(textBox1.Text);
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.LightGreen);
            for (int i = 0; i < 9; i++)
            {
                g.DrawLine(p, new Point((pictureBox1.Width / 10 * (i + 1)), 0), new Point((pictureBox1.Width / 10 * (i + 1)), pictureBox1.Height));
                g.DrawLine(p, new Point(0, (pictureBox1.Height / 10 * (i + 1))), new Point(pictureBox1.Width, (pictureBox1.Height / 10 * (i + 1))));
            }
            sm.compute();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    p.Color = colors[i];
                    p.Width = 8.0F;

                    if (sm.klaster[j] - 1 == i)
                    {
                        g.DrawEllipse(p, sm.xx[j] * X - 1, sm.xy[j] * Y - 1, 3, 3);
                        k[i]++;
                    }
                }
    
            }

            listBox1.Items.Clear();
            for (int i = 0; i< sm.zi; i++)
            {
                listBox1.Items.Add("Центр" + (i+1) +" = "+ sm.zx[i]+ ';' + sm.zy[i] + " точек: " + k[i]);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Kingroup kg = new Kingroup();
            kg.k = Convert.ToInt32(textBox2.Text);
            kg.compute();
            int kop = 0;
            int X = pictureBox1.Width / 10;
            int Y = pictureBox1.Height / 10;
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.LightGreen);
            for (int i = 0; i < 9; i++)
            {
                g.DrawLine(p, new Point((pictureBox1.Width / 10 * (i + 1)), 0), new Point((pictureBox1.Width / 10 * (i + 1)), pictureBox1.Height));
                g.DrawLine(p, new Point(0, (pictureBox1.Height / 10 * (i + 1))), new Point(pictureBox1.Width, (pictureBox1.Height / 10 * (i + 1))));
            }

            p.Width = 8.0F;

            for (int i = 0; i < kg.k; i++)
            {
                p.Color = colors[i];

                for (int j = 0; j < 10; j++)
                {
                    if (kg.klaster[j]-1 == i)
                    {
                        g.DrawEllipse(p, kg.xx[j] * X - 1, kg.xy[j] * Y - 1, 3, 3);
                        kop++;
                    }
                    
                }

                listBox1.Items.Add("Центр" + (i + 1) + " = " + kg.zx[i] + ';' + kg.zy[i] + " точек: " + kop);
                kop = 0;

            }

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            maxmin mami = new maxmin();
            mami.compute();
            int kop = 0;
            int X = pictureBox1.Width / 10;
            int Y = pictureBox1.Height / 10;
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.LightGreen);
            for (int i = 0; i < 9; i++)
            {
                g.DrawLine(p, new Point((pictureBox1.Width / 10 * (i + 1)), 0), new Point((pictureBox1.Width / 10 * (i + 1)), pictureBox1.Height));
                g.DrawLine(p, new Point(0, (pictureBox1.Height / 10 * (i + 1))), new Point(pictureBox1.Width, (pictureBox1.Height / 10 * (i + 1))));
            }

            p.Width = 8.0F;

            for (int i = 0; i < mami.zk; i++)
            {
                p.Color = colors[i];

                for (int j = 0; j < 10; j++)
                {
                    if (mami.klaster[j] - 1 == i)
                    {
                        g.DrawEllipse(p, mami.xx[j] * X - 1, mami.xy[j] * Y - 1, 3, 3);
                        kop++;
                    }

                }

                listBox1.Items.Add("Центр" + (i + 1) + " = " + mami.zx[i] + ';' + mami.zy[i] + " точек: " + kop);
                kop = 0;

            }
            

            
        }
    }
}
