using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private float gas = 100f;

    public int GetGas()
    {
        return (int) gas;
    }

    public void setGas(float value)
    {
        gas = value;
    }

    public void decreaseGas()
    {
        if (gas > 0.05f)
        {
            Debug.Log(gas);
            gas = gas - 0.05f;
        }
    }
}
