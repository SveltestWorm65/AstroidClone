using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Hud Text")]
    public TextMeshProUGUI waveCounter;
    public TextMeshProUGUI liveCounter;
    public TextMeshProUGUI scoreCounter;

    [Header("Ints")]
    public int score;
    public int lives;
    public int waves;

    [Header("Scripts")]
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //starting everything at default
        score = 0;
        lives = 0;
        waves = 1;

        //getting the gameObjects and components
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    //updating the score
    void UpdateScore()
    {
        scoreCounter.text = $"Score: {score}";
    }
    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        UpdateScore();
    }

    //updating the wave 
    public void UpdateWave()
    {
        waveCounter.text = $"Score: {waves}";
    }
    public void AddWave(int amountToAdd)
    {
        waves += amountToAdd;
        UpdateWave();
    }

    //Updating the lives
    public void UpdateLives()
    {
        liveCounter.text = $"Lives: {lives}";
    }
    public void AddLives(int AmountToAdd)
    {
        lives += AmountToAdd;
        UpdateLives();
    }

}
