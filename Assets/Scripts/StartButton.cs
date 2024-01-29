using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string gameStartScene;
    
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene(gameStartScene);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = ");
        SceneManager.LoadScene(gameStartScene);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(gameStartScene);
        }
        //SceneManager.LoadScene(gameStartScene);
    }


}
