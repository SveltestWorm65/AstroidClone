using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenControl : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Clockwise") || Input.GetButtonDown("CounterClockwise") || Input.GetButtonDown("Shoot") || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainLevel");
        }    
    }
}
