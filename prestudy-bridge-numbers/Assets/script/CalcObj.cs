using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CalcObj : MonoBehaviour
{
    //attacking this value
    public int attackAtThisValue;

    //if not hitting zero, what was left?
    public int remainder;

    //how many times did it take to attack the number?
    public int requiredNmbOfOperations;

    //did it hit zero? perhaps remainder tells?
    public bool DidHitZero;

    public string calculationRecord;
}
