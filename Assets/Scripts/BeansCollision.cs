using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansCollision : MonoBehaviour
{
    public GameObject canOfBeans;
    public GameObject randomObject;
    private Vector3 randomObjectPosition;

    void Start()
    {
        randomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        canOfBeans.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        randomObjectPosition = randomObject.GetComponent<Rigidbody>().transform.position;
        randomObject.GetComponent<Rigidbody>().transform.position = new Vector3(-randomObjectPosition.x, -randomObjectPosition.y, -randomObjectPosition.z);
    }
}
