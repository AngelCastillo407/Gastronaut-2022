using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RevealUI : MonoBehaviour
{

    private bool revealedUI = false;
    private Scene scene;

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if ( scene.name == "SampleScene" && !revealedUI)
        {
            transform.position = new Vector3(transform.position.x + 8000f, transform.position.y, transform.position.z);
            revealedUI = true;
        }  
    }
}
