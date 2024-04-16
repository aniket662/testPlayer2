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
        // Check if connected to Photon
        if (PhotonNetwork.IsConnected)
        {
            // Spawn the player prefab for each client
            SpawnPlayer();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // Spawn the player prefab for the new player
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // Generate a random position within the specified range
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Instantiate the player prefab
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        
        // Ensure that the local client owns the PhotonView of the player object
        PhotonView pv = player.GetComponent<PhotonView>();
        pv.TransferOwnership(PhotonNetwork.LocalPlayer);
    }
}
