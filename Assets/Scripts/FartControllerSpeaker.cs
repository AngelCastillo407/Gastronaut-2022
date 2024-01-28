using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartControllerSpeaker : MonoBehaviour
{

    private Gas playerGas = new Gas();
    private bool isFarting = false;
    private int randomNumber;
    public Animator animator;

    public GameObject randomObject;
    private Vector3 myRandomObjectPosition;

    void doneFarting()
    {
        isFarting = false;
        animator.SetTrigger("SpaceBarLetGo");
    }

    void Start()
    {
        myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space") && (playerGas.GetGas() > 0))
        {
            playerGas.decreaseGas();

            if (isFarting)
            {
                return;
            }

            animator.SetTrigger("SpaceBarHeld");
            randomNumber = Random.Range(1, 4);

            if (randomNumber == 1)
            {
                animator.SetTrigger("RandomlyChoseA");
            }

            else if (randomNumber == 2)
            {
                animator.SetTrigger("RandomlyChoseB");
            }

            else if (randomNumber == 3)
            {
                animator.SetTrigger("RandomlyChoseC");
            }

            else
            {
                animator.SetTrigger("RandomlyChoseABC");
            }

            isFarting = true;
        }

        if (Input.GetKeyUp("space") || playerGas.GetGas() <= 0)
        {
            doneFarting();
        }

        if (randomObject.GetComponent<Rigidbody>().transform.position != myRandomObjectPosition)
        {
            playerGas.addGas(33);
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }

    }
}
