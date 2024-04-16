using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start(){
        /*Vector2 randomPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);*/
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer();
        }
    }
    void SpawnPlayer()
    {
        // Generate a random position within the specified range
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
        // Instantiate the player prefab only on the local client
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        
        // Ensure that the local client owns the PhotonView of the player object
        PhotonView pv = player.GetComponent<PhotonView>();
        pv.TransferOwnership(PhotonNetwork.LocalPlayer);
    }
}

