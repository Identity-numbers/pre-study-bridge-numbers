using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //added links in UI
    public MainInterface mainInterface;
    public MainModel mainModel;

    //Button right calc
    public void rightCalculation()
    {
        mainModel.leftCalc();
    }

    //button left calc
    public void leftCalculation()
    {
        mainModel.rightCalc();
    }

}
