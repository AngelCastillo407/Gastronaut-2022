using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasGauge : MonoBehaviour
{
    private Gas playerGas = new Gas();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            playerGas.decreaseGas();
            GetComponent<Text>().text = playerGas.GetGas().ToString() + "%";
        }
    }
}
