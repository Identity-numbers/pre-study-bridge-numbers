using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //added links in UI
    public MainInterface mainInterface;
    public MainModel mainModel;

    //Button
    public void UpwardCalculation()
    {
        mainModel.CalcUpward();
    }
}
