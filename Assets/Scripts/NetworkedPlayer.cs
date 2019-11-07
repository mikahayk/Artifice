using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedPlayer : NetworkBehaviour
{

    [SyncVar]
    public int playerType = 0;

    public GameObject playerCamera;

    public GameObject avatar1;
    public GameObject avatar2;

    private void Start()
    {
        if(isLocalPlayer == true)
        {
            //enable the camera
            playerCamera.SetActive(true);
        }
    }


    // Local function to update my player type
    public void updateLocalPlayerType(int type)
    {
        //enforces that only localplayer can choose the player type
        if(isLocalPlayer)
        {
            CmdUpdatePlayerType(type);
        }  
    }

    private void Update()
    {
        avatar1.SetActive(true);
        /*
        if(playerType == 0)
        {
            
           

        } else if(playerType == 1)
        {
            avatar1.SetActive(false);
            avatar2.SetActive(true);
        }
        */
    }

    //Gets executed on the server
    [Command]
    void CmdUpdatePlayerType(int type)
    {
        playerType = type;
    }
}
