using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation2 : MonoBehaviour
{
    private GasGauge myGasGauge = new GasGauge();

    /*
        This is just me keeping this as knowing another way to rotate something.
        
        Works when you have something you want to rotate as the child of an empty game object.
        
        Very nice code indeed.
    */

    // Update is called once per frame
    void Update()
    {
        var myTransform = GetComponent<RectTransform>().transform;
        if (Input.GetKey("up"))
        {
            myTransform.RotateAround(myTransform.GetChild(0).position, Vector3.forward, 30 * Time.deltaTime);
        }

        if (Input.GetKey("down"))
        {
            myTransform.RotateAround(myTransform.GetChild(0).position, Vector3.back, 30 * Time.deltaTime);
        }
    }
}
