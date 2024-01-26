using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private bool facingBackwards = false;
    private Vector3 newRelativeLocation;

    private void Start()
    {
        newRelativeLocation = new Vector3(0, 1, -5);
        transform.position = player.transform.position + newRelativeLocation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + newRelativeLocation;

        if (Input.GetMouseButtonDown(0))
        {
            facingBackwards = !facingBackwards;
            transform.eulerAngles += new Vector3(x: 0f, y: 180f, z: 0f);
            newRelativeLocation = new Vector3(x: 0f, y: 1f, z: facingBackwards ? 5f : -5f);
        }

    }
}
