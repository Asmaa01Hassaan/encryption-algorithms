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
    public partial class Simple : Form
    {
        public int F ;
        public Simple()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (F == 0)//S-Aes
            {
                S_AES S = new S_AES();
                S.StartAlgo(textBox1.Text, textBox2.Text);
                label4.Text += S.Cipher;
                //inputs
                //P=1101011100101000
                //K=0100101011110101
               
            }
            if (F == 1)//RC4
            {
                RC4 R = new RC4();
                R.StartF(textBox2.Text, textBox1.Text);
               // MessageBox.Show(R.Key);
                label4.Text += R.Cipher;
                //p=1234
                //k=1236
                
                
            
            }
            MessageBox.Show("F = " + F);
        }
    }
}
