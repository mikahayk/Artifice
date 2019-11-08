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

    public GameObject avatarJudge;
    public GameObject avatarPlayer;

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
        if(playerType == 0)
        {
            avatarJudge.SetActive(false);
            avatarPlayer.SetActive(true);
           

        } else if(playerType == 1)
        {
            avatarJudge.SetActive(true);
            avatarPlayer.SetActive(false);
        }
        
    }

    //Gets executed on the server
    [Command]
    void CmdUpdatePlayerType(int type)
    {
        playerType = type;
    }
}
