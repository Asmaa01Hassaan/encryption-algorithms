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
    public partial class ELgamal : Form
    {
        public ELgamal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Elgamalcs H = new  Elgamalcs();
            H.StartAlgo(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
            label5.Text += " \n" + " Alice: Ya = " + H.Ya;
            label5.Text += " \n" + "Bob : K = " + H.Yb;
            label5.Text += " \n" + "Bob: C1 = " + H.C1;
            label5.Text += " \n" + "Bob :C2 = " + H.C2;
            label5.Text += " \n" + "Alice :KA = " + H.KA;
            label5.Text += " \n" + "Alice :K inverse = " + H.invK;
            label5.Text += " \n" + "Encrypted message M  = " + H.Mm;
        }
    }
}
