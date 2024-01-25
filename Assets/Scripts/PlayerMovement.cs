using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Gas playerGas = new Gas();
    public ParticleSystem fart;

    void leanForward()
    {
        var x = 0;
        for (x = 0; x < 90; x++) 
{
            GetComponent<Rigidbody>().transform.Rotate(x, 0f, 0f, Space.Self);
        }
    }

    void leanBackward()
    {
        var x = 0;
        for (x = 0; x < 90; x++)
        {
            GetComponent<Rigidbody>().transform.Rotate(-x, 0f, 0f, Space.Self);
        }
    }

    void leanLeft()
    {
        var x = 0;
        for (x = 0; x < 90; x++)
        {
            GetComponent<Rigidbody>().transform.Rotate(0f, 0f, x, Space.Self);
        }
    }

    void leanRight()
    {
        var x = 0;
        for (x = 0; x < 90; x++)
        {
            GetComponent<Rigidbody>().transform.Rotate(0f, 0f, -x, Space.Self);
        }
    }

    void fartUp()
    {
        // Apply 5 force in y direction
        GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 0);
    }

    void teleportFart()
    {
        // Teleport to x y z coordinates
        GetComponent<Rigidbody>().transform.Translate(0, 3, 0);
    }

    void relativeFart()
    {
        // Apply 15 force in current y direction
        GetComponent<Rigidbody>().AddRelativeForce(0, 15, 0);
    }

    void leanForwardSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(0.5f, 0f, 0f, Space.Self);
    }

    void leanBackwardSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(-0.5f, 0f, 0f, Space.Self);
    }

    void leanLeftSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(0f, 0f, 0.5f, Space.Self);
    }

    void leanRightSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(0f, 0f, -0.5f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            leanForwardSlow();
        }

        if (Input.GetKey("down"))
        {
            leanBackwardSlow();
        }

        if(Input.GetKey("left"))
        {
            leanLeftSlow();
        }

        if (Input.GetKey("right"))
        {
            leanRightSlow();
        }

        if (Input.GetKey("space") && (playerGas.GetGas() > 0))
        {
            playerGas.decreaseGas();
            relativeFart();
        }

        if (Input.GetKeyDown("space") && (playerGas.GetGas() > 0))
        {
            fart.Play();
        }

        if (Input.GetKeyUp("space"))
        {
            fart.Stop();
        }
    }
}