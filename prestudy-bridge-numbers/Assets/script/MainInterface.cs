using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{
    public InputField input_StartValue;
    public InputField input_StopValue;
    public InputField input_OutputField;

    public void AddOutputUpwardCalc(List<CalcObj> calcObjs)
    {
        //clean output
        CleanOutputField();

        //add what the information presented is about
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
            AddToOutput(calcObjs[i].calculationRecord + "\n", true);
        }
    }

    private void AddToOutput(string str, bool linebreak = true)
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

    public int[] ReturnStartAndStopValueUpward()
    {
        //check if startvalue is larger than stopvalue, stop or not?
        int startVal = int.Parse(input_StartValue.text);
        int stopVal = int.Parse(input_StopValue.text);

        //check input
        if (startVal < 0) { startVal = 0; }
        if (startVal >= stopVal) { stopVal = startVal + 1; }

        //re-add checked input
        input_StartValue.text = startVal.ToString();
        input_StopValue.text = stopVal.ToString();

        return new int[] { startVal, stopVal };
    }
}
