using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GasGauge : MonoBehaviour
{

    private Gas playerGas = new Gas();
    private const int GAS_INCREASE_FROM_BEANS = 40;

    public GameObject randomObject;
    private Vector3 myRandomObjectPosition;

    void Start()
    {
        myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            playerGas.decreaseGas();
            GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
        }

        if (randomObject.GetComponent<Rigidbody>().transform.position.x != myRandomObjectPosition.x)
        {
            playerGas.addGas(GAS_INCREASE_FROM_BEANS);
            GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }
    }
}
