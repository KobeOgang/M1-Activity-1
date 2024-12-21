using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public Transform[] spawnpoints;
    public GameObject player;
    private bool kill = true;

    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject SpawnsPlayer;

    private bool hasSpawned = false; 

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (kill == true)
            {
                RestartGame();
            }
        }
        if (Timer.activeInHierarchy)
        {
            if (hasSpawned) return;

            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                Timer.SetActive(false);
                SpawnPlayer();
                hasSpawned = true;
            }
        }
    }

    void SpawnPlayer()
    {
        int randomIndex = Random.Range(0, spawnpoints.Length);
        Transform chosenSpawnpoint = spawnpoints[randomIndex];

        Instantiate(player, chosenSpawnpoint.position, chosenSpawnpoint.rotation);

        Debug.Log($"Player spawned at spawn point: {chosenSpawnpoint.name}");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale in case the game was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RespawnPlayer()
    {
        SpawnsPlayer.SetActive(false);
        Timer.SetActive(true);
    }

}