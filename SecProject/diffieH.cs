using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecProject
{
    class diffieH
    {
        public int Q, A, Xa, Xb, Ya, Yb, Ka, Kb;

        public int Power(int Mm)
        {
            int ans = Mm * Mm;
            return ans;
        }
        public int ct;
        public void CalD(int Bmod, int Amod, int d)
        {
            ct += ((Bmod - d) / Amod);
        }
        public string GetBinC(int c)
        {
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
                if (cc > Q) { cc = (cc % Q); }
            }
            return cc;
        }
        public int binP;
        public void Computing_public_keyA()
        {
            //  Computing public keys
            int Pow = int.Parse(GetBinC(Xa));//get binary and delete unused 0's
            binP = Pow;
            string pb = binP.ToString();
            Ya = getValue(pb, A);//(using Squar Multiply)

        }
        public void Computing_public_keyB()
        {
            //char po = Xb.ToString()[0];
            int Pow = int.Parse(GetBinC(Xb));
            binP = Pow;
            string pb = binP.ToString();
            Yb = getValue(pb, A);

        }

        public void Computing_shared_session_key_KA()
        {
           // char po = Xa.ToString()[0];
            int Pow = int.Parse(GetBinC(Xa));
            binP = Pow;
            string pb = binP.ToString();
            Ka = getValue(pb, Yb);

        }
        public void Computing_shared_session_key_KB()
        {
            //char po = Xb.ToString()[0];
            int Pow = int.Parse(GetBinC(Xb));
            binP = Pow;
            string pb = binP.ToString();
            Kb = getValue(pb, Ya);

        }

        public void StartAlgo(int q, int a, int xa, int xb)
        {
            //set inputs valuse
            Q = q;
            A = a;
            Xa = xa;
            Xb = xb;
            Computing_public_keyA();
            Computing_public_keyB();
            Computing_shared_session_key_KA();
            Computing_shared_session_key_KB();

        }
    }
}
