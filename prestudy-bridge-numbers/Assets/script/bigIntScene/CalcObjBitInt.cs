using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CalcObjBitInt : MonoBehaviour
{
    //kind of calculation
    public string kindOfCalculation;
    //attacking this value
    public BigInteger attackAtThisValue;
    //length of original value
    public int numberOfDigits;
    //if not hitting zero, what was left?
    public BigInteger remainder;
    //how many times did it take to attack the number?
    public BigInteger requiredNmbOfOperations;
    //did it hit zero? perhaps remainder tells?
    public bool DidHitZero;
    public bool DidOverShoot = false;
    public string calculationRecord;
}
