using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour 
{
    PlacePlayer[] locations;
    
    void Start()
    {
        locations = GameObject.FindObjectsOfType<PlacePlayer>();
        Connect();
    }

    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("One and Only");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }
    void OnJoinedRoom()
    {
        PlacePlayer();
    }
    void PlacePlayer()
    {
        PlacePlayer myLocation = locations[Random.Range(0, locations.Length)];
        
        GameObject myPlayerGO = (GameObject) PhotonNetwork.Instantiate("PlayerController", myLocation.transform.position, myLocation.transform.rotation, 0);
        myPlayerGO.GetComponent<PlayerController>().enabled = true;
    }
   
}
