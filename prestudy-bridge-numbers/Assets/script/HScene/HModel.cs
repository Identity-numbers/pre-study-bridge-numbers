using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HModel : MonoBehaviour
{
    public HConstants hConstants;
    public HInterface hInterface;
    public GameObject Hprefab;
    public List<HCalcObj> HListCalcObjects = new List<HCalcObj>();


    private List<double> hConstantsList = new List<double>();

    public void RunFunc()
    {
        Debug.Log("Starting run function");
        GetConstantList();
        for (int i = 0; i < hConstantsList.Count; i++)
        {
            for (int j = 0; j < hConstantsList.Count; j++)
            {
                double bValue = hConstantsList[i];
                double pValue = hConstantsList[j];
                CalcOnObject(bValue, pValue);
            }
        }
        hInterface.AddToOutput(HListCalcObjects);
        hInterface.WriteString();

    }

    public void CalcOnObject(double baseValue, double powerValue)
    {
        Debug.Log(baseValue + " " + powerValue);

        GameObject go = Instantiate(Hprefab, new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity);
        HCalcObj calcObj = go.GetComponent(typeof(HCalcObj)) as HCalcObj;

        calcObj.baseNumber = baseValue;
        calcObj.powerNumber = powerValue;
        calcObj.calcMethod = "power smaller than one(1)";

        while (powerValue > 1)
        {
            powerValue /= 10F;
        }
        calcObj.modPowNmb = powerValue;

        double powerAns = Math.Pow(baseValue, powerValue);
        calcObj.beforeSqrt = powerAns;
        double answer = Math.Sqrt(powerAns);
        calcObj.answer = answer;

        HListCalcObjects.Add(calcObj);
    }

    public void GetConstantList()
    {
        hConstantsList.Add(hConstants.atomicMassConstant);
        hConstantsList.Add(hConstants.avogradosConstant);
        hConstantsList.Add(hConstants.bohrRadius);
        hConstantsList.Add(hConstants.charImpedanceVaccum);
        hConstantsList.Add(hConstants.cubeRootOfThree);
        hConstantsList.Add(hConstants.cubeRootOfTwo);
        hConstantsList.Add(hConstants.elementaryCharge);
        hConstantsList.Add(hConstants.eulersNumbers);
        hConstantsList.Add(hConstants.faradayConstant);
        hConstantsList.Add(hConstants.fermiCoupling);
        hConstantsList.Add(hConstants.goldenRation);
        hConstantsList.Add(hConstants.hartreeEnergy);
        hConstantsList.Add(hConstants.hyperfineTransFreq);
        hConstantsList.Add(hConstants.lemniscate);
        hConstantsList.Add(hConstants.molarGasConstant);
        hConstantsList.Add(hConstants.molarMassConstant);
        hConstantsList.Add(hConstants.molarMassofCarbon);
        hConstantsList.Add(hConstants.molarPlanckConstant);
        hConstantsList.Add(hConstants.neutronMass);
        hConstantsList.Add(hConstants.normalCount);
        hConstantsList.Add(hConstants.plancksConstant);
        hConstantsList.Add(hConstants.protonMass);
        hConstantsList.Add(hConstants.quantumOfCirculation);
        hConstantsList.Add(hConstants.rydbergConstant);
        hConstantsList.Add(hConstants.secondRadiationConstant);
        hConstantsList.Add(hConstants.sophomoreDream2);
        hConstantsList.Add(hConstants.sophomoresDream);
        hConstantsList.Add(hConstants.speedOfLight);
        hConstantsList.Add(hConstants.stefanBoltzmannConstant);
        hConstantsList.Add(hConstants.vaccumelectrpermitt);
        hConstantsList.Add(hConstants.vaccummagneticperme);
        hConstantsList.Add(hConstants.wallisConstant);
    }

    private void CleanCalcObj()
    {
        for (int i = 0; i < HListCalcObjects.Count; i++)
        {
            Destroy(HListCalcObjects[i].gameObject);
        }
        HListCalcObjects.Clear();
    }
}
