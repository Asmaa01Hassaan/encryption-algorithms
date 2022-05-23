using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecProject
{
   public class S_AES
    {
       public string  Cipher;
       public string PT = "", Key = "", W0 = "", W1 = "", W2 = "", W3 = "", W4 = "", W5 = "";
        string Const1 = "10000000", Const2 = "00110000";
        string[][] Table = new string[16][];
        string[][] MS = new string[2][];
        string[][] BinToDe = new string[16][];
        string[][] Addtion = new string[16][];
        string[][] Multi = new string[16][];
        int[][] GM = new int[2][];
        string[][] ConMs = new string[2][];
        string[][] Index = new string[6][];

     public  void setIndex()
       {
           Index[0] = new string[2] { "a", "10" };
           Index[1] = new string[2] { "b", "11" };
           Index[2] = new string[2] { "c", "12" };
           Index[3] = new string[2] { "d", "13" };
           Index[4] = new string[2] { "e", "14" };
           Index[5] = new string[2] { "f", "15" };
       }

    public int getIndex(string s)
     {
         int v = -1;
         for (int i = 0; i < Index.Count(); i++)
         {
             if (Index[i][0] == s)
             {
                 v = int.Parse(Index[i][1]);
                 break;

             }

         }
         return v;

     }

    public string XoR(string S1, string S2)
    {
        string Res = "";
        for (int i = 0; i < S1.Length; i++)
        {
            if (S1[i] == S2[i])
            {
                Res += 0;
            }
            else
            {
                Res += 1;
            }
        }

        return Res;
    }
    void SetBinToDe()//Bin = Hex
    {
        BinToDe[0] = new string[2] { "0000", "0" };
        BinToDe[1] = new string[2] { "0001", "1" };
        BinToDe[2] = new string[2] { "0010", "2" };
        BinToDe[3] = new string[2] { "0011", "3" };
        BinToDe[4] = new string[2] { "0100", "4" };
        BinToDe[5] = new string[2] { "0101", "5" };
        BinToDe[6] = new string[2] { "0110", "6" };
        BinToDe[7] = new string[2] { "0111", "7" };

        BinToDe[8] = new string[2] { "1000", "8" };
        BinToDe[9] = new string[2] { "1001", "9" };
        BinToDe[10] = new string[2] { "1010", "a" };
        BinToDe[11] = new string[2] { "1011", "b" };
        BinToDe[12] = new string[2] { "1100", "c" };
        BinToDe[13] = new string[2] { "1101", "d" };
        BinToDe[14] = new string[2] { "1110", "e" };
        BinToDe[15] = new string[2] { "1111", "f" };

    }
    string getBin(string ss)//get bin from hex
    {
        string S = "";
        for (int i = 0; i < BinToDe.Count(); i++)
        {
            if (BinToDe[i][1] == ss)
            {
                S = BinToDe[i][0];
                break;
            }
        }
        return S;
    }
    void SetMulti()//Multiplication Table
    {
        Multi[0] = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        Multi[1] = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        Multi[2] = new string[16] { "0", "2", "4", "6", "8", "a", "c", "e", "3", "1", "7", "5", "b", "9", "f", "d" };
        Multi[3] = new string[16] { "0", "3", "6", "5", "c", "f", "a", "9", "b", "8", "d", "e", "7", "4", "1", "2" };
        Multi[4] = new string[16] { "0", "4", "8", "c", "3", "7", "b", "f", "6", "2", "e", "a", "5", "1", "d", "9" };
        Multi[5] = new string[16] { "0", "5", "a", "f", "7", "2", "d", "8", "e", "b", "4", "1", "9", "c", "3", "6" };
        Multi[6] = new string[16] { "0", "6", "c", "a", "b", "d", "7", "1", "5", "3", "9", "f", "e", "8", "2", "4" };
        Multi[7] = new string[16] { "0", "7", "e", "9", "f", "8", "1", "6", "d", "a", "3", "4", "2", "5", "c", "b" };
        Multi[8] = new string[16] { "0", "8", "3", "b", "6", "e", "5", "d", "c", "4", "f", "7", "a", "2", "9", "1" };
        Multi[9] = new string[16] { "0", "9", "1", "8", "2", "b", "3", "a", "4", "d", "5", "c", "6", "f", "7", "e" };
        Multi[10] = new string[16] { "0", "a", "7", "d", "e", "4", "9", "3", "f", "5", "8", "2", "1", "b", "6", "c" };
        Multi[11] = new string[16] { "0", "b", "5", "e", "a", "1", "f", "4", "7", "c", "2", "9", "d", "6", "8", "3" };
        Multi[12] = new string[16] { "0", "c", "b", "7", "5", "9", "e", "2", "a", "6", "1", "d", "f", "3", "4", "8" };
        Multi[13] = new string[16] { "0", "d", "9", "4", "1", "c", "8", "5", "2", "f", "b", "6", "3", "e", "a", "7" };
        Multi[14] = new string[16] { "0", "e", "f", "1", "d", "3", "2", "c", "9", "7", "6", "8", "4", "a", "b", "5" };
        Multi[15] = new string[16] { "0", "f", "d", "2", "9", "6", "4", "b", "1", "e", "c", "3", "8", "7", "5", "a" };
    }
    string getDes(string s)//return Hexdecimal value
    {
        int v = 0;
        for (int i = 0; i < BinToDe.Count(); i++)
        {
            if (BinToDe[i][0] == s)
            {
                return BinToDe[i][1];
            }
        }

        return null;
    }
    void SetAddtion()
    {
        Addtion[0] = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        Addtion[1] = new string[16] { "1", "0", "3", "2", "5", "4", "7", "6", "9", "8", "b", "a", "d", "c", "f", "e" };
        Addtion[2] = new string[16] { "2", "3", "0", "1", "6", "7", "4", "5", "a", "b", "8", "9", "e", "f", "c", "d" };
        Addtion[3] = new string[16] { "3", "2", "1", "0", "7", "6", "5", "4", "b", "a", "9", "8", "f", "e", "d", "c" };
        Addtion[4] = new string[16] { "4", "5", "6", "7", "0", "1", "2", "3", "c", "d", "e", "f", "8", "9", "a", "b" };
        Addtion[5] = new string[16] { "5", "4", "7", "6", "1", "0", "3", "2", "d", "c", "f", "e", "9", "8", "b", "a" };
        Addtion[6] = new string[16] { "6", "7", "4", "5", "2", "3", "0", "1", "e", "f", "c", "d", "a", "b", "8", "9" };
        Addtion[7] = new string[16] { "7", "6", "5", "4", "3", "2", "1", "0", "f", "e", "d", "c", "b", "a", "9", "8" };
        Addtion[8] = new string[16] { "8", "9", "a", "b", "c", "d", "e", "f", "0", "1", "2", "3", "4", "5", "6", "7" };
        Addtion[9] = new string[16] { "9", "8", "b", "a", "d", "c", "f", "e", "1", "0", "3", "2", "5", "4", "7", "6" };
        Addtion[10] = new string[16] { "a", "b", "8", "9", "e", "f", "c", "d", "2", "3", "0", "1", "6", "7", "4", "5" };
        Addtion[11] = new string[16] { "b", "a", "9", "8", "f", "e", "d", "c", "3", "2", "1", "0", "7", "6", "5", "4" };
        Addtion[12] = new string[16] { "c", "d", "e", "f", "8", "9", "a", "b", "4", "5", "6", "7", "0", "1", "2", "3" };
        Addtion[13] = new string[16] { "d", "c", "f", "e", "9", "8", "b", "a", "5", "4", "7", "6", "1", "0", "3", "2" };
        Addtion[14] = new string[16] { "e", "f", "c", "d", "a", "b", "8", "9", "6", "7", "4", "5", "2", "3", "0", "1" };
        Addtion[15] = new string[16] { "f", "e", "d", "c", "b", "a", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" };
    }
    string v1, v2;
    void SetMS()
    {
        // mix columns 
        MS[0] = new string[2] { sS1, sS3 };
        MS[1] = new string[2] { sS4, sS2 };
        SetBinToDe();//Bin = Hex
        SetGM();//Set Me Matrix
        v1 = getDes(MS[0][0]);//return Hexdecimal value
        v2 = getDes(MS[0][1]);//return Hexdecimal value
        ConMs[0] = new string[2] { v1, v2 };
        v1 = getDes(MS[1][0]);
        v2 = getDes(MS[1][1]);
        ConMs[1] = new string[2] { v1, v2 };


        //MessageBox.Show(ConMs[0][0] + "      " + ConMs[0][ 1] + " \n" + ConMs[1][0] + "      " + ConMs[1][1] + " \n");
        SetMulti();//Multiplication Table
        SetAddtion();// Addition Table
        setIndex();
        MultiMatr();//(result of mix columns )1111 
        // 

    }
    string A = "", B = "", C = "", D = "", OP = "";
    int r, c, rr, cc;
    int IsNum(string s)
    {
        if (s[0] >= '0' && s[0] <= '9') { return 1; }

        return 0;
    }
    string Mix = "", MXK2 = "";
    void MultiMatr()//(result of mix columns )
    {

        A += ConMs[0][0];
        OP = "+";
        A += OP;
        r = GM[1][0];
        int k = IsNum(ConMs[1][0]);
        if (k == 0) { c = getIndex(ConMs[1][0]); }
        A += Multi[r][c];
        rr = int.Parse(A[0].ToString());
        k = IsNum(A[2].ToString());
        if (k == 0) { cc = getIndex(A[2].ToString()); }
        A = Addtion[rr][cc];

        // MessageBox.Show("A = " + getBin(A));

        B += ConMs[0][1];
        OP = "+";
        B += OP;
        r = GM[0][1];
        k = IsNum(ConMs[1][1]);
        if (k == 0) { c = getIndex(ConMs[1][1]); }
        B += Multi[r][c];
        k = IsNum(B[0].ToString());
        if (k == 0) { cc = getIndex(B[0].ToString()); }
        k = IsNum(B[2].ToString());
        if (k == 0) { rr = getIndex(B[2].ToString()); }
        B = Addtion[rr][cc];
        // MessageBox.Show("B = " + getBin(B));
        // MessageBox.Show("B = " + B);
        k = IsNum(ConMs[0][0]);
        if (k == 1) { int ans = GM[1][0] * int.Parse(ConMs[0][0]); C += ans; }
        OP = "+";
        C += OP;
        r = int.Parse(C[0].ToString());
        C += ConMs[1][0];
        k = IsNum(ConMs[1][0]);
        if (k == 0) { c = getIndex(C[2].ToString()); }
        C = Addtion[r][c];
        //MessageBox.Show("c = " + C);
        //MessageBox.Show("C = " + getBin(C));
        k = IsNum(ConMs[0][1]);
        if (k == 0) { c = getIndex(ConMs[1][0]); }
        r = GM[1][0];
        D += Multi[r][c];
        OP = "+";
        D += OP;
        D += ConMs[1][1];
        k = IsNum(D[0].ToString());
        if (k == 0) { rr = getIndex(D[0].ToString()); }

        k = IsNum(D[2].ToString());
        if (k == 0) { cc = getIndex(D[2].ToString()); }
        D = Addtion[rr][cc];
        //MessageBox.Show("D = " + D);
        //MessageBox.Show("D = " + getBin(D));
        //label3.Text += " \n";
        //label3.Text += " \n Mix = " + getBin(A) + "     " + getBin(B) + "     ";
        //label3.Text += " \n          " + getBin(C) + "     " + getBin(D) + "     ";
        Cipher += " \n";
        Cipher += " \n Mix = " + getBin(A) + "     " + getBin(B) + "     ";
        Cipher += " \n          " + getBin(C) + "     " + getBin(D) + "     ";
        Mix += getBin(A) + getBin(C) + getBin(B) + getBin(D);

        MXK2 += XoR(K1, Mix);
        //MessageBox.Show(MXK2);
        devideMXK2To4();//Get cipher text
    }
    string M1 = "", M2 = "", M3 = "", M4 = "", MS2 = "", cipher = "";
    void devideMXK2To4()//Get cipher text
    {
        //MessageBox.Show("Xor = " + MXK2);
        for (int i = 0; i < MXK2.Length; i++)
        {
            if (i < 4)
            {
                M1 += MXK2[i];
            }
            if (i >= 4 && i < 8)
            {
                M2 += MXK2[i];
            }
            if (i >= 8 && i < 12)
            {
                M3 += MXK2[i];
            }
            if (i >= 12 && i < 16)
            {
                M4 += MXK2[i];
            }

        }
        MS2 += searchW(M1) + searchW(M4) + searchW(M3) + searchW(M2);
        //MessageBox.Show("Ms2 = " + MS2);
        cipher += XoR(MS2, K2);
      
       // label3.Text += " \n Cipher Text = " + cipher + " \n";
        Cipher += " \n Cipher Text = " + cipher + " \n";
    }
    void SetGM()//Set Me Matrix
    {
        GM[0] = new int[2] { 1, 4 };
        GM[1] = new int[2] { 4, 1 };
    }
    void SetTable()//SubNib Table
    {
        Table[0] = new string[2] { "0000", "1001" };
        Table[1] = new string[2] { "0001", "0100" };
        Table[2] = new string[2] { "0010", "1010" };
        Table[3] = new string[2] { "0011", "1011" };
        Table[4] = new string[2] { "0100", "1101" };
        Table[5] = new string[2] { "0101", "0001" };
        Table[6] = new string[2] { "0110", "1000" };
        Table[7] = new string[2] { "0111", "0101" };

        Table[8] = new string[2] { "1000", "0110" };
        Table[9] = new string[2] { "1001", "0010" };
        Table[10] = new string[2] { "1010", "0000" };
        Table[11] = new string[2] { "1011", "0011" };
        Table[12] = new string[2] { "1100", "1100" };
        Table[13] = new string[2] { "1101", "1110" };
        Table[14] = new string[2] { "1110", "1111" };
        Table[15] = new string[2] { "1111", "0111" };

    }
    public string searchW(string ss)//get Nibble Substitution (S-Box) value
    {
        string oP = "";
        for (int i = 0; i < Table.Length; i++)
        {
            if (Table[i][0] == ss)
            {
                oP = Table[i][1];
                return oP;
            }
        }
        return null;
    }

    void DivideKey()//The input key, K, is split into 2 words, w0 and w1
    {
        for (int i = 0; i < Key.Length; i++)
        {
            if (i >= (Key.Length / 2))
            {
                W1 += Key[i];
            }
            else
            {
                W0 += Key[i];
            }
        }
        //  MessageBox.Show("W0: " + W0 + " \n" + "W1 : " + W1);
    }
    string wsup1 = "", wsup2 = "", SW1 = "", SN_RN1 = "", Ans = "";
    void SwapW1()//generate w2,w3 to get Key 1
    {
        for (int i = 0; i < W1.Length; i++)
        {
            if (i >= (W1.Length / 2))
            {
                wsup2 += W1[i];
            }
            else
            {
                wsup1 += W1[i];
            }
        }
        SW1 = wsup2 + wsup1;
        //  MessageBox.Show("after swap : " + SW1);
        SN_RN1 += searchW(wsup2);
        SN_RN1 += searchW(wsup1);
        //   MessageBox.Show("SN_RN1 : " + SN_RN1);
        Ans += XoR(SN_RN1, Const1);
        //  MessageBox.Show(Ans);\
        W2 += XoR(Ans, W0);
        //label3.Text += " \n" + "W2 = " + W2;
        Cipher += " \n" + "W2 = " + W2;
        //MessageBox.Show("W2 : "+W2);
        W3 += XoR(W2, W1);
       // label3.Text += " \n" + "W3 = " + W3;
        Cipher += " \n" + "W3 = " + W3;
    }
    string w3sup1 = "", w3sup2 = "", SN_RN2 = "", Ans2 = "", K1 = "", K2 = "", K0 = "";
    void SwapW3()
    {
        for (int i = 0; i < W3.Length; i++)
        {
            if (i >= (W3.Length / 2))
            {
                w3sup2 += W3[i];
            }
            else
            {
                w3sup1 += W3[i];
            }
        }
        // SW1 = wsup2 + wsup1;
        //  MessageBox.Show("after swap : " + SW1);
        SN_RN2 += searchW(w3sup2);
        SN_RN2 += searchW(w3sup1);
        //   MessageBox.Show("SN_RN1 : " + SN_RN1);
        Ans2 += XoR(SN_RN2, Const2);
        //  MessageBox.Show(Ans);\
        W4 += XoR(Ans2, W2);
        //label3.Text += " \n" + "W4 = " + W4;
        Cipher += " \n" + "W4 = " + W4;
        W5 += XoR(W4, W3);
      //  label3.Text += " \n" + "W5 = " + W5;
        Cipher += " \n" + "W5 = " + W5;
        K0 += W0 + W1;
        K1 += W2 + W3;
        K2 += W4 + W5;
        //label3.Text += " \n" + "K0 = " + K0;
        //label3.Text += " \n" + "K1 = " + K1;
        //label3.Text += " \n" + "K2 = " + K2;
        Cipher += " \n" + "K0 = " + K0;
        Cipher += " \n" + "K1 = " + K1;
        Cipher += " \n" + "K2 = " + K2;
    }
    string AdK1 = "", S1 = "", S2 = "", S3 = "", S4 = "";
    string sS1 = "", sS2 = "", sS3 = "", sS4 = "";
    string Sf1 = "";
    void devideTo4()// S = S00,S10,S01,S11
    {

        for (int i = 0; i < AdK1.Length; i++)
        {
            if (i < 4)
            {
                S1 += AdK1[i];
            }
            if (i >= 4 && i < 8)
            {
                S2 += AdK1[i];
            }
            if (i >= 8 && i < 12)
            {
                S3 += AdK1[i];
            }
            if (i >= 12 && i < 16)
            {
                S4 += AdK1[i];
            }

        }

    }
    void getFTable()//Nibble Substitution (S-Box) 
    {
        sS1 = searchW(S1);
        sS2 = searchW(S2);
        sS3 = searchW(S3);
        sS4 = searchW(S4);
        //MessageBox.Show(sS1 + sS2 + sS3 + sS4);
        Sf1 += sS1 + sS4 + sS3 + sS2;
        SetMS();
    }
    void Step2()
    {
        //Round One
        AdK1 += XoR(PT, K0);   //Plaintext xor Key0(given)
        //  MessageBox.Show("AdK1 : "+AdK1);
        devideTo4();// S = S00,S10,S01,S11
        getFTable();//Nibble Substitution (S-Box) 


    }

       public void StartAlgo(string K, string P)
       {
           PT = K;//key0   (Get input )
           Key = P;//plainText  (Get input )

           SetTable();//set SubNib Table
           //Key Generation
           DivideKey();//The input key, K, is split into 2 words, w0 and w1
           SwapW1();//generate w2,w3 to get Key 1
           SwapW3();//generate w4,w5 to get Key 2
           //Encryption ( round 1 and round 2) 
           Step2();
       }


    }
}

/* inputs
0100101011110101
1101011100101000
 */
