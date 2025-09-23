using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwapper : MonoBehaviour
{
    private bool didSwap = false;
    public AudioSource one;
    public AudioSource two;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !didSwap)
        {
            one.Stop();
            two.Play();
            didSwap = true;
        }
    }
}
