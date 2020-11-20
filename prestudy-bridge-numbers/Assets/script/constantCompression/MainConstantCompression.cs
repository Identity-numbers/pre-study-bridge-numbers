using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MainConstantCompression : MonoBehaviour
{
    /*
    PI
    0, 1, 4, 6, 7, 10, 14, 17, 26, 27, 30, 34, 37, 41, 42, 44, 52, 58, 
    0, 3, 5, 6, 9, 13, 16, 25, 26, 29, 33, 36, 40, 41, 43, 51, 57,
    0, 2, 5, 7, 8, 11, 15, 18, 27, 28, 31, 35, 38, 42, 43, 45, 53, 59

    https://oeis.org/A269101
    0, 3, 6, 8, 9, 12, 16, 19, 28, 29, 32, 36, 39, 43, 44, 46, 54, 60,

    0, 4, 7, 9, 10, 13, 17, 20, 29, 30, 33, 37, 40, 44, 45, 47, 55, 61,
    0, 5, 8, 10, 11, 14, 18, 21, 30, 31, 34, 38, 41, 45, 46, 48, 56, 62  

    A247935
    0, 5, 8, 10, 11, 14, 18, 21, 30, 31, 34, 38, 41, 45, 46, 48, 56, 62

    A085722
    0, 6, 9, 11, 12, 15, 19, 22, 31, 32, 35, 39, 42, 46, 47, 49, 57, 63

    A325854
    0, 7, 10, 12, 13, 16, 20, 23, 32, 33, 36, 40, 43, 47, 48, 50, 58, 64

    A246371
    0, 8, 11, 13, 14, 17, 21, 24, 33, 34, 37, 41, 44, 48, 49, 51, 59, 65, 

    A105115
    0, 9, 12, 14, 15, 18, 22, 25, 34, 35, 38, 42, 45, 49, 50, 52, 60, 66

    A196091
    0, 10, 13, 15, 16, 19, 23, 26, 35, 36, 39, 43, 46, 50, 51, 53, 61, 67,

    A075472
    ================================
    A001690, A070115
    0, 2, 7, 9, 10, 11, 12, 14, 19, 26, 28, 35, 37, 38, 40, 43, 46, 47, 48, 51,

    0, 1, 3, 8, 10, 11, 12, 13, 15, 20, 27, 29, 36, 38, 39, 41, 44, 47, 48, 49, 52

    0, 2, 4, 9, 11, 12, 13, 14, 16, 21, 28, 30, 37, 39, 40, 42, 45, 48, 49, 50, 53, 

    A037369
    0, 7, 9, 14, 16, 17, 18, 19, 21, 26, 33, 35, 42, 44, 45, 47, 50, 53, 54, 55, 58, 
    */
    public BigInteger piConstBig;
    public string piStr = "31415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";
    public string eStr = "27182818284590452353602874713526624977572470936999595749669676277240766303535475945713821785251664274274663919320030";

    public List<int> accSeq = new List<int>();
    void Start()
    {
        //piConst = BigInteger.Parse(piStr);
        AccConstant(eStr);
        printList();
    }

    public void AccConstant(string strConst)
    {
        //clear list
        accSeq.Clear();

        //add initial zero
        accSeq.Add(0);

        //loop through string length
        for (int i = 0; i < strConst.Length; i++)
        {
            //what was the last digit?
            int currNumb = accSeq[i];

            int accInt = 7;
            while (accInt <= currNumb)
            {
                if (strConst.Length > 2)
                {
                    string str = strConst.Substring(0, 1);
                    strConst = strConst.Substring(1, strConst.Length - 1);
                    accInt += int.Parse(str);
                }
                else
                {
                    break;
                }
            }
            accSeq.Add(accInt);
        }
    }

    public void printList()
    {
        string str = "";
        for (int i = 0; i < accSeq.Count; i++)
        {
            str += accSeq[i] + ", ";
        }
        Debug.Log(str);
    }
}
