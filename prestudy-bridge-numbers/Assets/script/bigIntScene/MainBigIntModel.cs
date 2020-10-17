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

    public List<string> ListOfConstants = new List<string>();

    private void getListOfConstants()
    {
        ListOfConstants.Add(constants.BackhouseConstant);
        ListOfConstants.Add(constants.Catalan);
        ListOfConstants.Add(constants.Copeland_Erdos_constant);
        ListOfConstants.Add(constants.ExpE);
        ListOfConstants.Add(constants.EulerConstant);
        ListOfConstants.Add(constants.Exp2);
        ListOfConstants.Add(constants.ExpGamma);
        ListOfConstants.Add(constants.ExpInvertE);
        ListOfConstants.Add(constants.ExpPi);
        ListOfConstants.Add(constants.ExpPiDiv4);
        ListOfConstants.Add(constants.expPiMinusPi);
        ListOfConstants.Add(constants.FeigenBaumDelta);
        ListOfConstants.Add(constants.goldenRatio);
        ListOfConstants.Add(constants.inverseLog2);
        ListOfConstants.Add(constants.kinchin);
        ListOfConstants.Add(constants.str_E);
        ListOfConstants.Add(constants.str_Pi);
        ListOfConstants.Add(constants.str_sQrt2);
        ListOfConstants.Add(constants.str_sQrt3);
        ListOfConstants.Add(constants.This_number_exp2_7div2);
        /**/
    }

    public void RunFunc()
    {
        //Debug.Log("start called : ");
        //fill list with constants
        getListOfConstants();

        //Debug.Log("constant list : " + ListOfConstants.Count);

        //CleanCalcObj();

        //loop here for massive testing
        string hitVal = "0";

        for (int i = 0; i < ListOfConstants.Count; i++)
        {
            for (int j = 0; j < ListOfConstants.Count; j++)
            {
                if (i != j)
                {
                    Debug.Log("inside loop");
                    string startV = ListOfConstants[i];
                    string stopV = ListOfConstants[j];
                    //Debug.Log("This is times: " + i + " " + j);
                    topCalcBigInt(hitVal, startV, stopV);
                }
            }
        }

        mainBigIntInterface.WriteString();
    }
    private void CleanCalcObj()
    {
        for (int i = 0; i < ListCalcObjectsBigInt.Count; i++)
        {
            Destroy(ListCalcObjectsBigInt[i].gameObject);
        }
        ListCalcObjectsBigInt.Clear();
    }

    public void topCalcBigInt(string hitVal, string ConstantStartVal, string ConstantStopVal)
    {
        //reset old stuff
        CleanCalcObj();

        //mainBigIntInterface.AddToOutput("\n\n*****************************************************************************");
        //mainBigIntInterface.AddToOutput("                                                                     ");
        if (hitVal.Length > 1)
        {
            //BigInteger HitThisValue = 
            //mainBigIntInterface.AddToOutput("Hitval     : " + hitVal.Substring(0, 20));
        }
        else
        {
            //BigInteger HitThisValue = 0;
            //mainBigIntInterface.AddToOutput("Hitval     : " + hitVal);
        }
       // mainBigIntInterface.AddToOutput("Start Value: " + ConstantStartVal.Substring(0, 20));
        //mainBigIntInterface.AddToOutput("Stop Value : " + ConstantStopVal.Substring(0, 20));
        //mainBigIntInterface.AddToOutput("                                                                     ");
        //mainBigIntInterface.AddToOutput("*****************************************************************************");

        //BigInteger HitThisValue = 

        //get iteration
        int loop = mainBigIntInterface.getLoops();

        //loop through and get each number length
        for (int i = 0; i < loop; i++)
        {
            //curr values to chop down
            BigInteger currBigIntStartVal = getBigInt(ConstantStartVal, i);
            BigInteger currBigIntStopVal = getBigInt(ConstantStopVal, i);
            //            Debug.Log("currBigIntStartVal: " + currBigIntStartVal);

            //setup CalcObj
            GameObject go = Instantiate(prefabBigInt, new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity);
            CalcObjBitInt calcObj = go.GetComponent(typeof(CalcObjBitInt)) as CalcObjBitInt;

            calcObj.kindOfCalculation = "reducing from top";
            calcObj.attackAtThisValue = currBigIntStartVal;
            calcObj.calculationRecord = currBigIntStartVal.ToString();
            calcObj.numberOfDigits = i + 1;

            ListCalcObjectsBigInt.Add(calcObj);

            //loop througn the number and see if it hits zero
            long escaper = 0;
            long iter = 0;

            BigInteger firstVal = currBigIntStartVal;
            BigInteger attackingVal = currBigIntStopVal;

            while (true)
            {
                iter++;

                while (attackingVal > firstVal)
                {
                    attackingVal = reduceNumberFromTop(attackingVal); // /= 10;
                    //attackingVal /= 10;
                }

                firstVal -= attackingVal;

                if (firstVal == 0)
                {
                    Debug.Log("did hit zero");
                    //did hit zero
                    calcObj.DidHitZero = true;
                    calcObj.remainder = firstVal;
                    calcObj.requiredNmbOfOperations = iter;
                    calcObj.calculationRecord += "-" + attackingVal.ToString();
                    break;
                }

                if (firstVal < 0)
                {
                    Debug.Log("did overshoot");
                    //did overshoot
                    calcObj.DidHitZero = false;
                    calcObj.remainder = firstVal + attackingVal;
                    calcObj.requiredNmbOfOperations = iter - 1;
                    //calcObj.calculationRecord += "+" + attackingVal.ToString();
                    break;
                }
                else
                {
                    calcObj.calculationRecord += "-" + attackingVal.ToString();
                }

                if (attackingVal == 0)
                {
                    //nothing more to attack with
                    calcObj.DidHitZero = false;
                    calcObj.remainder = firstVal;
                    calcObj.requiredNmbOfOperations = iter;
                    break;
                }

                escaper++;
                if (escaper > 1000)
                {
                    //Debug.Log("did use escaper for this while loop with limig: 2000");
                    break;
                }
            }

        }
        mainBigIntInterface.AddOutputTopCalc(ListCalcObjectsBigInt);
        
    }
    private BigInteger reduceNumberFromTop(BigInteger lNmb)
    {
        BigInteger returnNmb;
        string strlNmb = lNmb.ToString();
        if (strlNmb.Length > 1)
        {
            strlNmb = strlNmb.Substring(1, strlNmb.Length - 1);
            returnNmb = BigInteger.Parse(strlNmb);
        }
        else
        {
            returnNmb = 0;
        }
        return returnNmb;
    }
    private BigInteger getBigInt(string strConstant, int atIndex)
    {
        string strBigInt = strConstant.Substring(0, atIndex + 1);
        //Debug.Log(strBigInt);
        BigInteger bigInteger = BigInteger.Parse(strBigInt);
        return bigInteger;
    }
}
