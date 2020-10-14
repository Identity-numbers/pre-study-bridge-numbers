using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class MainBigIntInterface : MonoBehaviour
{
    public InputField input_Loops;
    public InputField input_OutputField;

    public int getLoops()
    {
        int returnval = int.Parse(input_Loops.text);
        return returnval;
    }

    public void AddOutputTopCalc(List<CalcObjBitInt> calcObjBitInt)
    {
        //clean output
        CleanOutputField();

/*         //add what the information presented is about
        AddToOutput("Upward Calculation ======================= ");
        AddToOutput("\nRun on following numbers: ");
        for (int i = 0; i < calcObjs.Count; i++)
        {
            AddToOutput(calcObjs[i].attackAtThisValue + ", ", false);
        }
        AddToOutput("\n\nRequired subtractive operations: ");
        //m
        for (int i = 0; i < calcObjs.Count; i++)
        {
            AddToOutput(calcObjs[i].requiredNmbOfOperations + ", ", false);
        }
        AddToOutput("\n\nLowest possible remainder: ");
        for (int i = 0; i < calcObjs.Count; i++)
        {
            AddToOutput(calcObjs[i].remainder + ", ", false);
        }
        AddToOutput("\n\nDid hit a perfect zero?:  ", true);
        for (int i = 0; i < calcObjs.Count; i++)
        {
            AddToOutput(calcObjs[i].DidHitZero + ", ", false);
        }
        AddToOutput("\n\nSubtraction chain:  ", true);
        for (int i = 0; i < calcObjs.Count; i++)
        {
            AddToOutput("Did hit zero = " + calcObjs[i].DidHitZero, true);
            AddToOutput(calcObjs[i].calculationRecord + "\n", true);
        } */
    }

    public void AddToOutput(string str, bool linebreak = true)
    {
        if (linebreak)
        {
            input_OutputField.text += str + "\n";
        }
        else
        {
            input_OutputField.text += str;
        }
    }

    private void CleanOutputField()
    {
        input_OutputField.text = "";
    }
}
