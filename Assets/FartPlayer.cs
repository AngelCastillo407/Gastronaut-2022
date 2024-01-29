using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartPlayer : MonoBehaviour
{
    public AudioSource one;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            one.Play();
        }
        else
        {
            one.Stop();
        }
    }
}
