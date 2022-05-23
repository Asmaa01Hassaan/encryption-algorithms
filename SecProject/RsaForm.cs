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
    public partial class RsaForm : Form
    {
        public RsaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSA R = new RSA();
            R.StartAlgo(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            string d = (R.ct).ToString();
            label5.Text += " \n" + "D = " + d;
            R.Encrypt();
           // label5.Text += " \n" + "BinaryP = " + R.binP.ToString();
            label5.Text += " \n" + "C = " + R.C.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RSA R = new RSA();
            R.StartAlgo(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            R.Encrypt();
            string d = (R.ct).ToString();
            //label5.Text += " \n" + "D = " + d;
            //label5.Text += " \n" + "C = " + R.C.ToString();
            R.Decrypt();
          //  label5.Text += " \n" + "BinaryP = " + R.binP.ToString();
            label5.Text += " \n" + "M = " + R.DM.ToString();
        }
    }
}
