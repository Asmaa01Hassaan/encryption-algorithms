using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecProject
{
    public partial class DiffieHelman : Form
    {
        public DiffieHelman()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diffieH H = new diffieH();
            H.StartAlgo(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            label5.Text += " \n" + "Ya = " + H.Ya;
            label5.Text += " \n" + "Yb = " + H.Yb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            diffieH H = new diffieH();
            H.StartAlgo(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            label5.Text += " \n" + "Ka = " + H.Ka;
            label5.Text += " \n" + "Kb = " + H.Kb;
        }
    }
}
