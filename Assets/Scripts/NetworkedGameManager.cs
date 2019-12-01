using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedGameManager : MonoBehaviour
{
    public GameObject bot1;
    public GameObject bot2;
    public GameObject botPlayer;
 
    public void UpdatePlayerType()
    {
        //find all the networked players
        NetworkedPlayer[] players = FindObjectsOfType<NetworkedPlayer>();

        //for each player found, update localplayertype
        foreach(NetworkedPlayer np in players)
        {
            np.updateLocalPlayerType(1);
        }
     
    }

    public void Play()
    {
        Debug.Log("GAME STARTED");



    }

    public void Pause()
    {
        Debug.Log("PAUSE");
        bot1.GetComponent<Animator>().enabled = false;
        bot2.GetComponent<Animator>().enabled = false;

        botPlayer.GetComponent<NetworkedPlayer>().leftController.SetActive(false);
        botPlayer.GetComponent<NetworkedPlayer>().rightController.SetActive(false);


    }
}
