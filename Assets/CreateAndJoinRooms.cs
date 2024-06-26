using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField joinInput;
    public InputField createInput;

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}