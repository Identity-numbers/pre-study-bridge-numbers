using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CalcObj : MonoBehaviour
{
    //kind of calculation
    public string kindOfCalculation;
    //attacking this value
    public long attackAtThisValue;

    //if not hitting zero, what was left?
    public long remainder;

    //how many times did it take to attack the number?
    public long requiredNmbOfOperations;

    //did it hit zero? perhaps remainder tells?
    public bool DidHitZero;

    public string calculationRecord;
}
