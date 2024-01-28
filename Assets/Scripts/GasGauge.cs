using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GasGauge : MonoBehaviour
{
    public GameObject randomObject;
    private Vector3 myRandomObjectPosition;

    private Gas playerGas = new Gas();

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
            playerGas.addGas(33);
            GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }
    }
}
