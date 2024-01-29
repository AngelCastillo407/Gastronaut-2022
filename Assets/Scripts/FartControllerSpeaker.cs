using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartControllerSpeaker : MonoBehaviour
{

    private Gas playerGas = new Gas();
    private bool isFarting = false;
    private const int GAS_INCREASE_FROM_BEANS = 40;

    public Animator animator;
    public GameObject randomObject;

    private Vector3 myRandomObjectPosition;
    private int randomNumber;

    private Vector3 myRandomObjectScale;
    private bool gameHasToReset;

    public GameObject RestartButton;

    void doneFarting()
    {
        isFarting = false;
        animator.SetTrigger("SpaceBarLetGo");
    }

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
            animator.SetTrigger("RanOutOfGas");
        }

        if (gameHasToReset)
        {
            //if (randomObject.GetComponent<Transform>().localScale != myRandomObjectScale)
            //{
            //    playerGas.setGas(100f);
            //    gameHasToReset = false;
            //    doneFarting();
            //}

            
            if (RestartButton.GetComponent<Transform>().localScale != myRandomObjectScale)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    RestartButton.SetActive(true);
                    playerGas.setGas(100f);
                    gameHasToReset = false;
                    doneFarting();
                    animator.ResetTrigger("RanOutOfGas");
                }
            }

            Debug.Log("woohoo");
        }

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
            playerGas.addGas(GAS_INCREASE_FROM_BEANS);
            myRandomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        }

    }
}
