using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Gas playerGas = new Gas();
    const int GAS_INCREASE_FROM_BEANS = 40;

    public GameObject randomObject;
    private Vector3 myRandomObjectPosition;
    private Vector3 myRandomObjectScale;
    public ParticleSystem fart;
    public GameObject RestartButton;

    public bool gameHasToReset = false;

    //public AudioSource one;

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
        GetComponent<Rigidbody>().transform.Rotate(1.5f, 0f, 0f, Space.Self);
    }

    void leanBackwardSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(-1.5f, 0f, 0f, Space.Self);
    }

    void leanLeftSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(0f, 0f, 1.5f, Space.Self);
    }

    void leanRightSlow()
    {
        GetComponent<Rigidbody>().transform.Rotate(0f, 0f, -1.5f, Space.Self);
    }

    void Start()
    {
        myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        myRandomObjectScale = randomObject.GetComponent<Rigidbody>().transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("space"))
        //{
        //    one.Play();
        //}
        //else
        //{
        //    one.Stop();
        //}

        if (! (playerGas.GetGas() > 0))
        {
            gameHasToReset = true;
        }

        if (gameHasToReset)
        {
            RestartButton.SetActive(true);
            //if (randomObject.GetComponent<Transform>().localScale != myRandomObjectScale)
            //{
            //    playerGas.setGas(100f);
            //    transform.position = new Vector3(0, 0, 0);
            //    gameHasToReset = false;
            //    RestartButton.SetActive(false);
            //}

            if (randomObject.GetComponent<Transform>().localScale != myRandomObjectScale)
            {
                playerGas.setGas(100f);
                gameHasToReset = false;
                transform.position = new Vector3(0, 0, 0);
            }


        }

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            leanForwardSlow();
        }

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            leanBackwardSlow();
        }

        if(Input.GetKey("left") || Input.GetKey("a"))
        {
            leanLeftSlow();
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            leanRightSlow();
        }

        if (Input.GetKey("space") && (playerGas.GetGas() > 0) && !gameHasToReset)
        {
            playerGas.decreaseGas();
            relativeFart();
        }

        if (Input.GetKeyDown("space") && (playerGas.GetGas() > 0) && !gameHasToReset)
        {
            fart.Play();
        }

        if (Input.GetKeyUp("space") || gameHasToReset)
        {
            fart.Stop();
        }

        if (randomObject.GetComponent<Rigidbody>().transform.position != myRandomObjectPosition)
        {
            playerGas.addGas(GAS_INCREASE_FROM_BEANS);
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }
    }
}