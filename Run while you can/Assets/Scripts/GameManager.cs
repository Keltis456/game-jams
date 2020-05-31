using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

internal class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public float ySpawnPoint;
    public Coin coin;
    public Spikes spikes;
    public float GlobalSpeed;
    private float score;

    public float Score
    { 
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score: {(int)score}";
        }
    }

    public TMP_Text scoreText;
    private float spawnRandomObstaclesCounter;

    private void Update()
    {
        Score += GlobalSpeed * Time.deltaTime;
        spawnRandomObstaclesCounter += GlobalSpeed * Time.deltaTime;
        if (spawnRandomObstaclesCounter >= 3)
        {
            SpawnRandomObstacles();
            spawnRandomObstaclesCounter = 0;
        }
        GlobalSpeed += Time.deltaTime/10;
    }

    public void GameOver()
    {
        SaveScores();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        SaveScores();
    }

    private void SaveScores()
    {
        PlayerPrefs.SetInt("LastScore", (int)Score);
        if ((int)Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)Score);
        }
        PlayerPrefs.Save();
    }

    private void SpawnRandomObstacles()
    {
        var spikesCount = 0;
        var coinsCount = 0;

        var places = new Dictionary<LinePosition, int>
        {
            {LinePosition.Left, 0}, {LinePosition.Middle, 0}, {LinePosition.Right, 0}
        };
        foreach (var place in places)
        {
            var random = Random.Range(0, 3);
            switch (random)
            {
                case 1:
                    if (spikesCount >= 1)
                    {
                        
                    }
                    else
                    {
                        Instantiate(spikes, new Vector3((int) place.Key, ySpawnPoint), Quaternion.identity);
                    }
                    spikesCount++;
                    break;
                case 2:
                    if (coinsCount >= 1)
                    {
                        
                    }
                    else
                    {
                        Instantiate(coin, new Vector3((int) place.Key, ySpawnPoint), Quaternion.identity);
                    }
                    coinsCount++;
                    break;
            }
        }
    }
}