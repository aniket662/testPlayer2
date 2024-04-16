using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        // Check if connected to Photon and if this client is the master client
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            // Spawn the player prefab for the master client
            SpawnPlayer();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // Check if this client is not the master client
        if (!PhotonNetwork.IsMasterClient)
        {
            // Spawn the player prefab for the second player
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        // Generate a random position within the specified range
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Instantiate the player prefab
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }
}
