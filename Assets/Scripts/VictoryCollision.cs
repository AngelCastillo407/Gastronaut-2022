using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCollision : MonoBehaviour
{
    public GameObject Text, Gif1, Gif2, ScreenTint, Player;

    // Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        Text.SetActive(true);
        Gif1.SetActive(true);
        Gif2.SetActive(true);
        ScreenTint.SetActive(true);
        Player.GetComponent<Rigidbody>().drag = .3f;
    }
}
