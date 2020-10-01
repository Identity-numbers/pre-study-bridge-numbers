using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{
    public InputField input_StartValue;
    public InputField input_StopValue;
    public InputField input_OutputField;

    public void AddOutputUpwardCalc()
    {
        input_OutputField.text = "Upward Calculation: \n";
    }
}
