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
    public int maxLives;
    public int waves;

    public bool Invince;

    [Header("Scripts")]
    public PlayerController playerController;
    public SpawnManager sm;
    // Start is called before the first frame update
    void Start()
    {
        //starting everything at default
        score = 0;
        lives = 3;
        waves = 1;

        //getting the gameObjects and components
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        
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
    public void AddWave(int WaveToAdd)
    {
        if(sm.enemyCount == 0)
        {
            waves += WaveToAdd;
            UpdateWave();
        }
       
        
    }

    //Updating the lives
    public void UpdateLives()
    {
        liveCounter.text = $"Lives: {lives}";
    }
    public void LooseLife()
    {
        if (Invince == false)
        {
            lives -= 1;
            UpdateLives();
        }

        
    }
   /* public void AddLives(int AmountToAdd)
    {
        lives += AmountToAdd;
        UpdateLives();
    }*/

}
