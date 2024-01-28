using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private float gas = 100f;
    private float gasDecrease = 0.01f;

    public int GetGas()
    {
        return (int) gas;
    }

    public void setGas(float value)
    {
        gas = value;
    }

    public void addGas(int value)
    {
        float convertedValue = (float) value;
        if (gas + convertedValue > 100f)
        {
            gas = 100f;
        }
        else
        {
            gas += convertedValue;
        }
    }

    public void decreaseGas()
    {
        if (gas > gasDecrease)
        {
            gas = gas - gasDecrease;
        }
    }
}
