using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GasGauge : MonoBehaviour
{
    private Gas playerGas = new Gas();

    public int getRotationValue()
    {
        return playerGas.GetGas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            playerGas.decreaseGas();
            GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
        }
    }
}
