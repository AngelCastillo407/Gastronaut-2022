using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{

    private Gas playerGas = new Gas();
    const int GAS_INCREASE_FROM_BEANS = 40;

    public GameObject randomObject;
    private Vector3 myRandomObjectPosition;
    private float[] possibleDegrees;

    private Vector3 myRandomObjectScale;
    private bool gameHasToReset;

    float[] initRotationRange()
    {
        int x = 0;
        float max = (float) (84 + 1.54);
        float min = -70f;
        float degree1 = 1.68f;
        float degree2 = 1.4f;
        float[] possibleDegrees = new float[100];
        for (x = 1; x <= 100; x++)
        {
            possibleDegrees[x-1] = (x <= 50) ? max - (degree1 * x) : possibleDegrees[x-2] - degree2;
        }
        return possibleDegrees;
    }

    // 68.6, 53.2, 37.8
    void Start()
    {
        possibleDegrees = initRotationRange();
        GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, possibleDegrees[playerGas.GetGas() - 1]);
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
                GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, possibleDegrees[99]);
                gameHasToReset = false;
            }
        }

        if (Input.GetKey("space") && (playerGas.GetGas() > 0))
        {
            playerGas.decreaseGas();
            // Looks like extra if-statement but actually serves a purpose 
            // Sometimes with floats you subtract by something like 1.001 giving you a negative number
            if (playerGas.GetGas() > 0)
            {
                GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, possibleDegrees[playerGas.GetGas() - 1]);
            }
        }

        if (randomObject.GetComponent<Rigidbody>().transform.position != myRandomObjectPosition)
        {
            playerGas.addGas(GAS_INCREASE_FROM_BEANS);
            GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, possibleDegrees[playerGas.GetGas() - 1]);
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }

    }
}
