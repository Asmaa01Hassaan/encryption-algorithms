using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecProject
{
    class Elgamalcs
    {
        public int Q, A, Xa, Xb, Ya, Yb, Ka, Kb, RK, EM, C1, C2, KA, Mm;

        public int Power(int Mm)
        {
            int ans = Mm * Mm;
            return ans;
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
            //char po = Xa.ToString()[0];
            int Pow = int.Parse(GetBinC(Xa));
            binP = Pow;
            string pb = binP.ToString();
            Ya = getValue(pb, A);

        }
        public void Computing_public_keyB()
        {
            //char po = RK.ToString()[0];
            int Pow = int.Parse(GetBinC(RK));
            binP = Pow;
            string pb = binP.ToString();
            Yb = getValue(pb, Ya);

        }
        public void CalcC1()
        {
            // char po = RK.ToString()[0];
            int Pow = int.Parse(GetBinC(RK));
            binP = Pow;
            string pb = binP.ToString();
            C1 = getValue(pb, A);
        }
        public void CalcC2()
        {
            C2 = (Yb * EM) % Q;
        }
        public int invK, invK2;
        public int ct = 0, ct2 = 0;
        List<List<int>> Subeq = new List<List<int>>();
     
        int CalcK_1(int a, int m)////Calc K inverse 
        {
            a = a % m;
            for (int x = 1; x < m; x++)
                if ((a * x) % m == 1)
                    return x;
            return 1;

        }
        public void Step4()
        {
            Console.WriteLine("\n Get K inverse \n");
            int Bmod = Q, Amod = KA;
            //invK = Bmod % Amod;
            invK = CalcK_1(KA, Q);//Calc K inverse 
            Console.WriteLine("K inverse" + invK);

        }
        void Step5()
        {
            Mm = (C2 * invK) % Q;
        }
        void step4Alice()
        {
            CalcKalice();//Calc K
            Step4();//Calc K inverse 
            Step5();//Calc M
        }
        public void CalcKalice() //Calc K using SM 
        {
            // char po = Xa.ToString()[0];
            int Pow = int.Parse(GetBinC(Xa));
            binP = Pow;
            string pb = binP.ToString();
            KA = getValue(pb, C1);
        }

        public void StartAlgo(int q, int a, int xa, int rk, int eM)
        {
            //set input
            Q = q;
            A = a;
            Xa = xa;
            RK = rk;
            EM = eM;
            Computing_public_keyA();
            Computing_public_keyB();
            CalcC1();  //Alice C1
            CalcC2();  //Alice C2
            step4Alice();

        }
    }
}
