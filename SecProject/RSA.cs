using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecProject
{
    class RSA
    {
        public int P, Q, E, M, n, Fin, D, C = 1, binP, DM,Gc;
        public string Powerx, rule;


        public void Step1()
        {
            // Calculate “system modulus”
            n = P * Q;
        }
        public void Step2()
        {
            // Calculate “Eular function”
            Fin = (P - 1) * (Q - 1);
        }
        public int ct;
     
        int CalcK_1(int a, int m)
        {
            a = a % m;
            int x = 1;
            while (x < m)
            {
                if ((a * x) % m == 1)
                    return x;
                x++;
            }
            return 1;

        }
        public void Step4()
        {
            // Calculate d “Decryption Key”
            int Bmod = Fin, Amod = E;
            D = CalcK_1(E, Fin);
            ct = D;
        }
        public int Power(int Mm)
        {
            // Q =( Square ) 
            int ans = Mm * Mm;
            return ans;
        }
        public string GetBinC(int c)
        {
            //get binary number 
            char m = (char)1;
            string pb = "";
            for (int i = 7; i >= 0; i--)
            {
                int bit = c & ((m << i));
                if (bit != 0) { bit = 1; }
                pb += bit.ToString();
            }
            
            return pb;
        }

        string ans;
        public int getValue(string ss, int mb)
        {
            //using Square Multiply
            int cc = 1;
            ans = "";
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i] == '1') { ans += "QM"; }
                if (ss[i] == '0') { ans += "Q"; };
            }
            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i] == 'Q') { cc = Power(cc); }
                if (ans[i] == 'M') { cc *= mb; }
                if (cc > n) { cc = (cc % n); }
            }
            return cc;
        }

        public void Encrypt()
        {
          
            string po = GetBinC(E); //get binary number 
            int Pow = int.Parse(po);//to delete unused 0's
            binP = Pow;
            string pb = binP.ToString();
            C = getValue(pb, M);//using Square Multiply

        }

        public void Decrypt()
        {

            string po = GetBinC(ct);//get binary number 
            int Pow = int.Parse(po);//to delete unused 0's
            binP = Pow;
            string pb = binP.ToString();//convert it to string 
            DM = getValue(pb, C);//using Square Multiply

        }

        public void StartAlgo(int p, int q, int e, int m)
        {
            //set input
            P = p;
            Q = q;
            E = e;
            M = m;
           
            Step1();
            Step2();
            Step4();
        }
    }
}
