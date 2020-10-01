using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel : MonoBehaviour
{
    public MainInterface mainInterface;
    public void CalcUpward()
    {
        mainInterface.AddOutputUpwardCalc();
    }
}
