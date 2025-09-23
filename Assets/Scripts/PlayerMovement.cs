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

    // Original speed is 0.5f
    // build speed is 2.5f
    private float rotationSpeed = 0.8f;

    private int upCounter, downCounter, leftCounter, rightCounter = 0;

    void relativeFart()
    {
        // Apply 15 force in current y direction
        GetComponent<Rigidbody>().AddRelativeForce(0, 15, 0);
    }

    void leanForward(int count)
    {
        if (count < 20)
        {
            GetComponent<Rigidbody>().transform.Rotate(2.25f, 0f, 0f, Space.Self);
        }
    }

    void leanBackward(int count)
    {
        if (count < 20)
        {
            GetComponent<Rigidbody>().transform.Rotate(-2.25f, 0f, 0f, Space.Self);
        }
    }

    void leanLeft(int count)
    {
        if (count < 20)
        {
            GetComponent<Rigidbody>().transform.Rotate(0f, 0f, 2.25f, Space.Self);
        }
    }

    void leanRight(int count)
    {
        if (count < 20)
        {
            GetComponent<Rigidbody>().transform.Rotate(0f, 0f, -2.25f, Space.Self);
        }
    }

    void Start()
    {
        myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        myRandomObjectScale = randomObject.GetComponent<Rigidbody>().transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!(playerGas.GetGas() > 0))
        {
            gameHasToReset = true;
        }

        if (gameHasToReset)
        {
            RestartButton.SetActive(true);

            if (randomObject.GetComponent<Transform>().localScale != myRandomObjectScale)
            {
                playerGas.setGas(100f);
                gameHasToReset = false;
                transform.position = new Vector3(0, 0, 0);
            }

        }

        if (upCounter > 0 && upCounter < 20)
        {
            leanForward(upCounter);
            upCounter += 1;
        }

        if (downCounter > 0 && downCounter < 20)
        {
            leanBackward(downCounter);
            downCounter += 1;
        }

        if (leftCounter > 0 && leftCounter < 20)
        {
            leanLeft(leftCounter);
            leftCounter += 1;
        }

        if (rightCounter > 0 && rightCounter < 20)
        {
            leanRight(rightCounter);
            rightCounter += 1;
        }

        if (Input.GetKeyDown("w"))
        {
            upCounter += 1;
        }

        if (Input.GetKeyUp("w"))
        {
            upCounter = 0;
            downCounter = 1;
        }

        if (Input.GetKeyDown("s"))
        {
            downCounter += 1;
        }

        if (Input.GetKeyUp("s"))
        {
            downCounter = 0;
            upCounter = 1;
        }

        if (Input.GetKeyDown("a"))
        {
            leftCounter += 1;
        }

        if (Input.GetKeyUp("a"))
        {
            leftCounter = 0;
            rightCounter = 1;
        }

        if (Input.GetKeyDown("d"))
        {
            rightCounter += 1;
        }

        if (Input.GetKeyUp("d"))
        {
            rightCounter = 0;
            leftCounter = 1;
        }

        if (upCounter == 20)
        {
            upCounter = 0;
        }

        if (downCounter == 20)
        {
            downCounter = 0;
        }

        if (leftCounter == 20)
        {
            leftCounter = 0;
        }

        if (rightCounter == 20)
        {
            rightCounter = 0;
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