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

        GameObject.Find("Countdown").GetComponent<CountdownController>().enabled = true;


        // Enable the bots
        bot1.SetActive(true);
        bot2.SetActive(true);

        // Start animating the bots
        bot1.GetComponent<Animator>().enabled = true;
        bot2.GetComponent<Animator>().enabled = true;

        // Enable actor controllers
        botPlayer.GetComponent<NetworkedPlayer>().leftController.SetActive(true);
        botPlayer.GetComponent<NetworkedPlayer>().rightController.SetActive(true);


    }

    public void Pause()
    {
        Debug.Log("PAUSE");

        // Stop animating the bots
        bot1.GetComponent<Animator>().enabled = false;
        bot2.GetComponent<Animator>().enabled = false;


        // Disable actor controllers
        botPlayer.GetComponent<NetworkedPlayer>().leftController.SetActive(false);
        botPlayer.GetComponent<NetworkedPlayer>().rightController.SetActive(false);


    }
}
