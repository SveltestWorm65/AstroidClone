using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OnPlayButton(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}