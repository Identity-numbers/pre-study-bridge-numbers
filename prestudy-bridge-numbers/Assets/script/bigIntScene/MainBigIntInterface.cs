using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class MainBigIntInterface : MonoBehaviour
{
    public InputField input_Loops;
    public InputField input_OutputField;

    public int getLoops()
    {
        int returnval = int.Parse(input_Loops.text);
        return returnval;
    }

    public void AddOutputTopCalc(List<CalcObjBitInt> calcObjBitInt)
    {
        //clean output
        CleanOutputField();

        //add what the information presented is about
        AddToOutput("TopCalc Calculation ======================= ");
                AddToOutput("\n==================:: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {

                AddToOutput(calcObjBitInt[i].requiredNmbOfOperations + ", ", false);

            //AddToOutput(calcObjBitInt[i].attackAtThisValue + ", ", false);
        }
        AddToOutput("\n==================:: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].DidHitZero)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
            //AddToOutput(calcObjBitInt[i].attackAtThisValue + ", ", false);
        }
        AddToOutput("\n\n==================:: ");
        //m
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 1)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 2)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 3)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 4)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 5)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 6)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 7)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 8)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        AddToOutput("\n\n==================: ");
        for (int i = 0; i < calcObjBitInt.Count; i++)
        {
            if (calcObjBitInt[i].remainder == 9)
            {
                AddToOutput(calcObjBitInt[i].numberOfDigits + ", ", false);
            }
        }
        /*       AddToOutput("\n\nLowest possible remainder: ");
               for (int i = 0; i < calcObjs.Count; i++)
               {
                   AddToOutput(calcObjs[i].remainder + ", ", false);
               }
               AddToOutput("\n\nDid hit a perfect zero?:  ", true);
               for (int i = 0; i < calcObjs.Count; i++)
               {
                   AddToOutput(calcObjs[i].DidHitZero + ", ", false);
               }
               AddToOutput("\n\nSubtraction chain:  ", true);
               for (int i = 0; i < calcObjs.Count; i++)
               {
                   AddToOutput("Did hit zero = " + calcObjs[i].DidHitZero, true);
                   AddToOutput(calcObjs[i].calculationRecord + "\n", true);
               } */
    }

    public void AddToOutput(string str, bool linebreak = true)
    {
        if (linebreak)
        {
            input_OutputField.text += str + "\n";
        }
        else
        {
            input_OutputField.text += str;
        }
    }

    private void CleanOutputField()
    {
        input_OutputField.text = "";
    }
}
