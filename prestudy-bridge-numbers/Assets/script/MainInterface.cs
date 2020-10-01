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
        input_OutputField.text = "Upward Calculation: \n";
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

        return new int[]{startVal,stopVal};
    }
}
