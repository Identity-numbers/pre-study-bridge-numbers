using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel : MonoBehaviour
{
    public MainInterface mainInterface;
    public GameObject prefab;

    public List<CalcObj> ListCalcObjects = new List<CalcObj>();

    private void CleanCalcObj()
    {
        for (int i = 0; i < ListCalcObjects.Count; i++)
        {
            Destroy(ListCalcObjects[i].gameObject);
        }
        ListCalcObjects.Clear();
    }
    private long reduceNumberFromTop(long lNmb)
    {
        long returnNmb;
        string strlNmb = lNmb.ToString();
        if (strlNmb.Length > 1)
        {
            strlNmb = strlNmb.Substring(1, strlNmb.Length - 1);
            returnNmb = long.Parse(strlNmb);
        }
        else
        {
            returnNmb = 0;
        }
        return returnNmb;
    }
    public void topCalc()
    {
        //clean up object and list
        CleanCalcObj();

        //get start and stop value
        long[] intStartStop = mainInterface.ReturnStartAndStopTopCalc();
        long startV = intStartStop[0];
        long stopV = intStartStop[1];

        if (stopV - startV > 200)
        {
            //safety
            stopV = startV + 200;
            mainInterface.AddToOutput("Safety is on, only doing 200 iterations for .");
        }

        //loop through start and stop value
        for (long i = startV - 1; i < stopV; i++)
        {
            //setup CalcObj
            GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            CalcObj calcObj = go.GetComponent(typeof(CalcObj)) as CalcObj;

            //current value to chop down
            long firstVal = i + 1;

            //reduce number from top
            long attackingVal = reduceNumberFromTop(firstVal);// firstVal / 10;

            calcObj.kindOfCalculation = "reducing from top";
            calcObj.attackAtThisValue = firstVal;
            calcObj.calculationRecord = firstVal.ToString();

            ListCalcObjects.Add(calcObj);

            long iter = 0;

            //nothing to attack with, continue;
            if (attackingVal == 0)
            {
                calcObj.DidHitZero = false;
                calcObj.remainder = firstVal;
                calcObj.requiredNmbOfOperations = 0;
                //break loop and continue with next value
                continue;
            }

            long escaper = 0;
            //attacking value
            while (true)
            {
                iter++;

                firstVal -= attackingVal;
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
                }

                escaper++;
                if (escaper > 100)
                {
                    Debug.Log("did use escaper for this while loop");
                    break;
                }
            }

            //Debug.Log(iter);
            /* */
        }

        mainInterface.AddOutputLeftCalc(ListCalcObjects);

    }

    public void bottomCalc()
    {
        //clean up object and list
        CleanCalcObj();

        //get start och stop value, validated in mainInterface
        long[] intStartStop = mainInterface.ReturnR_StartAndStopBottomCalc();
        long startV = intStartStop[0];
        long stopV = intStartStop[1];

        if (stopV - startV > 200)
        {
            //safety
            stopV = startV + 200;
            mainInterface.AddToOutput("Safety is on, only doing 200 iterations.");
        }

        //loop through start and stop value
        for (long i = startV - 1; i < stopV; i++)
        {
            //setup CalcObj
            GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            CalcObj calcObj = go.GetComponent(typeof(CalcObj)) as CalcObj;

            //current value to chop down
            long firstVal = i + 1;
            long attackingVal = firstVal / 10;
            calcObj.kindOfCalculation = "reducing from bottom";
            calcObj.attackAtThisValue = firstVal;
            calcObj.calculationRecord = firstVal.ToString();

            ListCalcObjects.Add(calcObj);

            long iter = 0;

            //nothing to attack with, continue;
            if (attackingVal == 0)
            {
                calcObj.DidHitZero = false;
                calcObj.remainder = firstVal;
                calcObj.requiredNmbOfOperations = 0;
                //break loop and continue with next value
                continue;
            }

            long escaper = 0;
            //attacking value
            while (true)
            {
                iter++;

                firstVal -= attackingVal;
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
                    attackingVal /= 10;
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
                if (escaper > 100)
                {
                    Debug.Log("did use escaper for this while loop");
                    break;
                }
            }

            //Debug.Log(iter);
        }

        mainInterface.AddOutputLeftCalc(ListCalcObjects);
    }
}
