using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MainBigIntModel : MonoBehaviour
{
    public MainBigIntInterface mainBigIntInterface;
    public GameObject prefabBigInt;
    public Constants constants;

    public List<CalcObjBitInt> ListCalcObjectsBigInt = new List<CalcObjBitInt>();

    private void CleanCalcObj()
    {
        for (int i = 0; i < ListCalcObjectsBigInt.Count; i++)
        {
            Destroy(ListCalcObjectsBigInt[i].gameObject);
        }
        ListCalcObjectsBigInt.Clear();
    }

    public void topCalcBigInt()
    {
        CleanCalcObj();

        //get iteration
        int loop = mainBigIntInterface.getLoops();

        //loop through and get each number length
        for (int i = 0; i < loop; i++)
        {
            //curr values to chop down
            BigInteger currBigIntStartVal = getBigInt(constants.str_Pi, i);
            BigInteger currBigIntStopVal = getBigInt(constants.str_E, i);
            Debug.Log("currBigIntStartVal: " + currBigIntStartVal);

            //setup CalcObj
            GameObject go = Instantiate(prefabBigInt, new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity);
            CalcObjBitInt calcObj = go.GetComponent(typeof(CalcObjBitInt)) as CalcObjBitInt;

            calcObj.kindOfCalculation = "reducing from top";
            calcObj.attackAtThisValue = currBigIntStartVal;
            calcObj.calculationRecord = currBigIntStartVal.ToString();

            ListCalcObjectsBigInt.Add(calcObj);

            //loop througn the number and see if it hits zero
            long escaper = 0;
            long iter = 0;

            while (true)
            {
                iter++;

                /*                 firstVal -= attackingVal;
                                //Debug.Log("firstval: " + firstVal + " attackingval; " + attackingVal);

                                calcObj.calculationRecord += "-" + attackingVal.ToString();

                                if (firstVal == 0)
                                {
                                    Debug.Log("did hit zero");
                                    //did hit zero
                                    calcObj.DidHitZero = true;
                                    calcObj.remainder = firstVal;
                                    calcObj.requiredNmbOfOperations = iter;
                                    break;
                                }

                                if (firstVal < 0)
                                {
                                    Debug.Log("did overshoot");
                                    //did overshoot
                                    calcObj.DidHitZero = false;
                                    calcObj.remainder = firstVal + attackingVal;
                                    calcObj.requiredNmbOfOperations = iter - 1;
                                    calcObj.calculationRecord += "+" + attackingVal.ToString();
                                    break;
                                }

                                while (attackingVal > firstVal)
                                {
                                    attackingVal = reduceNumberFromTop(attackingVal); // /= 10;
                                }

                                if (attackingVal == 0)
                                {
                                    //nothing more to attack with
                                    calcObj.DidHitZero = false;
                                    calcObj.remainder = firstVal;
                                    calcObj.requiredNmbOfOperations = iter;
                                    break;
                                } */

                escaper++;
                if (escaper > 100)
                {
                    Debug.Log("did use escaper for this while loop");
                    break;
                }
            }

            mainBigIntInterface.AddOutputTopCalc(ListCalcObjectsBigInt);
        }
    }

    private BigInteger getBigInt(string strConstant, int atIndex)
    {
        string strBigInt = strConstant.Substring(0, atIndex + 1);
        Debug.Log(strBigInt);
        BigInteger bigInteger = BigInteger.Parse(strBigInt);
        return bigInteger;
    }
}
