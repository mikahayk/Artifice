using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedGameManager : MonoBehaviour
{
 
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
}
