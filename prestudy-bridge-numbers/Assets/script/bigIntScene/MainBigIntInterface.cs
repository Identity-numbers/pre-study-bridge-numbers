using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using UnityEditor;
using System.IO;

public class MainBigIntInterface : MonoBehaviour
{
    public InputField input_Loops;
    public InputField input_OutputField;

    public TextAsset textAsset;

    private string outPutString;

    public int getLoops()
    {
        int returnval = int.Parse(input_Loops.text);
        return returnval;
    }

    public void AddOutputTopCalc(List<CalcObjBitInt> calcObjBitInt)
    {
        //clean output
        //CleanOutputField();

        //add what the information presented is about
        //AddToOutput("Calculation type: TopCalc Calculation");
        //AddToOutput("\n\nRequired number of operations to reach close or to zero: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {

            //AddToOutput(calcObjBitInt[i].requiredNmbOfOperations + ", ", false);

            //AddToOutput(calcObjBitInt[i].attackAtThisValue + ", ", false);
        }
        AddToOutput("\n");
        //AddToOutput("\n\n(0) ================== (Did hit zero) : ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].DidHitZero)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
            //AddToOutput(calcObjBitInt[i].attackAtThisValue + ", ", false);
        }
       // AddToOutput("\n\n(1) ==================: ");
        //m
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 1)
            {
               // AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(2) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 2)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(3) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 3)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(4) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 4)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(5) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 5)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(6) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 6)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(7) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 7)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(8) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 8)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        //AddToOutput("\n\n(9) ==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 9)
            {
                //AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }

    }

    public void AddToOutput(string str, bool linebreak = true)
    {
        if (linebreak)
        {
            //input_OutputField.text += str + "\n";
            outPutString += str + "\n";
        }
        else
        {
            //input_OutputField.text += str;
            outPutString += str;
        }
    }

    private void CleanOutputField()
    {
        //input_OutputField.text = "";
        outPutString = "";
    }

    public void WriteString()
    {
        string path = "Assets/TextAssets/outText.txt";

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(outPutString);
        writer.Close();

        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(path); 
        //TextAsset asset = Resources.Load("test");

        //Print the text from the file
        //Debug.Log(asset.text);
    }
}
