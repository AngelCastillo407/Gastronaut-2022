using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathActivated : MonoBehaviour
{
    public GameObject randomObject;

    void Start()
    {
        randomObject.transform.localScale = new Vector3(randomObject.transform.localScale.x + 0.5f, randomObject.transform.localScale.y + 0.5f, randomObject.transform.localScale.z + 0.5f);
    }


}