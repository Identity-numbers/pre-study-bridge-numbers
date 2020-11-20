using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{
    //Bottom calc input
    public InputField input_StartValue;
    public InputField input_StopValue;

    //Top calc Frac input
    public InputField inputRFrac_StartValue;
    public InputField inputRFrac_StopValue;

    //Top calc input
    public InputField inputR_StartValue;
    public InputField inputR_StopValue;

    //Single Bottom Calc
    public InputField inputSBC_StartValue;
    public InputField inputSBC_StopValue;

    //Single Top Calc
    public InputField inputSTC_StartValue;
    public InputField inputSTC_StopValue;
    public InputField input_OutputField;

    public void AddOutputLeftCalc(List<CalcObj> calcObjs)
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
            AddToOutput("Did hit zero = " + calcObjs[i].DidHitZero, true);
            AddToOutput("Number of iterations = " + calcObjs[i].requiredNmbOfOperations + ", ", true);
            AddToOutput(calcObjs[i].calculationRecord + "\n", true);
        }
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
    public long[] ReturnR_StartAndStopBottomCalc()
    {
        //check if startvalue is larger than stopvalue, stop or not?
        long startVal = long.Parse(input_StartValue.text);
        long stopVal = long.Parse(input_StopValue.text);

        //check input
        if (startVal < 0) { startVal = 0; }
        if (startVal >= stopVal) { stopVal = startVal + 1; }

        //re-add checked input
        input_StartValue.text = startVal.ToString();
        input_StopValue.text = stopVal.ToString();

        return new long[] { startVal, stopVal };
    }
    
    public long[] ReturnStartAndStopTopCalcFrac()
    {
        //check if startvalue is larger than stopvalue, stop or not?
        long startVal = long.Parse(inputR_StartValue.text);
        long stopVal = long.Parse(inputR_StopValue.text);

        //check input
        if (startVal < 0) { startVal = 0; }
        if (startVal >= stopVal) { stopVal = startVal + 1; }

        //re-add checked input
        inputRFrac_StartValue.text = startVal.ToString();
        inputRFrac_StopValue.text = stopVal.ToString();

        Debug.Log("startVal: " + startVal);

        return new long[] { startVal, stopVal };
    }

    public long[] ReturnStartAndStopTopCalc()
    {
        //check if startvalue is larger than stopvalue, stop or not?
        long startVal = long.Parse(inputR_StartValue.text);
        long stopVal = long.Parse(inputR_StopValue.text);

        //check input
        if (startVal < 0) { startVal = 0; }
        if (startVal >= stopVal) { stopVal = startVal + 1; }

        //re-add checked input
        inputR_StartValue.text = startVal.ToString();
        inputR_StopValue.text = stopVal.ToString();

        Debug.Log("startVal: " + startVal);

        return new long[] { startVal, stopVal };
    }
    public long[] ReturnSingleBottomCalcValues()
    {
                //check if startvalue is larger than stopvalue, stop or not?
        long startVal = long.Parse(inputSBC_StartValue.text);
        long stopVal = long.Parse(inputSBC_StopValue.text);

        //check input
        //if (startVal < 0) { startVal = 0; }
        //if (startVal >= stopVal) { stopVal = startVal + 1; }

        //re-add checked input, do I need to do this? in this case
        inputSBC_StartValue.text = startVal.ToString();
        inputSBC_StopValue.text = stopVal.ToString();

        return new long[] { startVal, stopVal };
    }
    public long[] ReturnSingleTopCalcValues()
    {
                        //check if startvalue is larger than stopvalue, stop or not?
        long startVal = long.Parse(inputSTC_StartValue.text);
        long stopVal = long.Parse(inputSTC_StopValue.text);

        //check input
        //if (startVal < 0) { startVal = 0; }
        //if (startVal >= stopVal) { stopVal = startVal + 1; }

        //re-add checked input
        inputSTC_StartValue.text = startVal.ToString();
        inputSTC_StopValue.text = stopVal.ToString();

        return new long[] { startVal, stopVal };
    }

}
