﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecProject
{
    public class RC4
    {
        //Step 1: Generating State vector  
        public string Svector = "01234567", Tvector = "", Key, PlainText,Cipher;
        public void StartF(string K , string P)
        {

            Key = K; //Set Key (input)
            PlainText = P; //Set Plain text (input)
            Tvector = FillTvector(Key);//generate Temporary vector
            initialPermutation();//Initial Permutation pseudo code on S
            Encryption();
        }
        public string FillTvector(string St)//generate Temporary vector
        {
            string Tem = "";
            Tem = St + St;
            return Tem;
        }

    public void Swap(int i, int j)
      {
          char[] array = Svector.ToCharArray();
          char temp = array[i];
          array[i] = array[j];
          array[j] = temp;
          Svector = new string(array);
      }

    ////Initial Permutation pseudo code on S
    public void initialPermutation()
      {
          int j = 0;
          for (int i = 0; i < 8; i++)
          {
              j = ((j + (int)Svector[i] + (int)Tvector[i]) % 8);
              Swap(i, j);
              //  MessageBox.Show("Mod" + i + " =  " + j);
          }

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



      public int ei = 0, pi = 0;

        
      public void Encryption()
      {
          //Now we generate 3-bits at a time, k, 
          //that we XOR with each 3-bits of plaintext to produce the ciphertext. 
          //The 3-bits k is generated by: 
          int j = 0, t = 0;
          char k;
          while (pi < PlainText.Length)
          {
              ei = (ei + 1) % 8;
              j = (j + (int)Svector[ei]) % 8;
              Swap(ei, j);
              t = ((int)Svector[ei] + (int)Svector[j]) % 8;
              k = Svector[t];


              //  MessageBox.Show("Bin = " + GetBinC(k) + "Bin2 = " + GetBinC(textBox2.Text[pi]));
              string Res = XoR(GetBinC((int)k), GetBinC((int)PlainText[pi]));
              // MessageBox.Show(Res);
              Res = Convert.ToInt32(Res, 2).ToString();
              //  MessageBox.Show(Res);
              Cipher+= Res;
              pi++;
          }

      }

    }
}