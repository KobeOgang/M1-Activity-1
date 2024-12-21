using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints; 
    private GameObject currentPlayer; 

    void Start()
    {
        
    }

    public void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer method called");
        currentPlayer = GameObject.FindGameObjectWithTag("Player");

        if (currentPlayer != null)
        {
            Debug.Log($"Destroying current player: {currentPlayer.name}");
            Destroy(currentPlayer);
        }
        else
        {
            Debug.Log("No current player to destroy");
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        currentPlayer.tag = "Player";
        Debug.Log($"New player spawned: {currentPlayer.name} at {spawnPoint.position}");
    }
}
