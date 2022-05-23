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
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Simple form2 = new Simple();
            form2.F = 0;
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Simple form2 = new Simple();
            form2.F = 1;
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RsaForm Rf = new RsaForm();
            Rf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiffieHelman D_H = new DiffieHelman();
            D_H.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ELgamal E = new ELgamal();
            E.ShowDialog();
        }
    }
}
