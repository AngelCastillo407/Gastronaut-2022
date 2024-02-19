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

    private Vector3 myRandomObjectScale;
    private bool gameHasToReset;

    void Start()
    {
        myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        myRandomObjectScale = randomObject.GetComponent<Rigidbody>().transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (!(playerGas.GetGas() > 0))
        {
            gameHasToReset = true;
        }

        if (gameHasToReset)
        {
            if (randomObject.GetComponent<Transform>().localScale != myRandomObjectScale)
            {
                playerGas.setGas(100f);
                gameHasToReset = false;
                GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
            }
        }

        if (Input.GetKey("space"))
        {
            playerGas.decreaseGas();
            GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
        }

        // Position of Random Object has changed
        // This means a can of beans has been collected
        if (randomObject.GetComponent<Rigidbody>().transform.position.x != myRandomObjectPosition.x)
        {
            playerGas.addGas(GAS_INCREASE_FROM_BEANS);
            GetComponent<TextMeshPro>().text = playerGas.GetGas().ToString() + "%";
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }
    }
}
