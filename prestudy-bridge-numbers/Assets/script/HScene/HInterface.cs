using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using UnityEditor;
using System.IO;

public class HInterface : MonoBehaviour
{
    public TextAsset textAsset;
    private string outPutString;

    public void AddToOutput(List<HCalcObj> hCalcObj)
    {
        for (int i = 0; i < hCalcObj.Count; i++)
        {
            AddToOutput("========= CalcMethod: " + hCalcObj[i].calcMethod);
            AddToOutput("Base Number: " + hCalcObj[i].baseNumber);
            AddToOutput("Pow Number : " + hCalcObj[i].powerNumber);
            AddToOutput("Mod Pow Nmb: " + hCalcObj[i].modPowNmb);
            AddToOutput("Before Sqrt: " + hCalcObj[i].beforeSqrt);
            AddToOutput("Answer     : " + hCalcObj[i].answer);
            AddToOutput("\n");
        }
    }

    private void CleanOutputField()
    {
        outPutString = "";
    }

    public void AddToOutput(string str, bool linebreak = true)
    {
        if (linebreak)
        {
            outPutString += str + "\n";
        }
        else
        {
            outPutString += str;
        }
    }

    public void WriteString()
    {
        string path = "Assets/TextAssets/houtText.txt";

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
