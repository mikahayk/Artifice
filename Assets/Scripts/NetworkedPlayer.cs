using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedPlayer : NetworkBehaviour
{

    [SyncVar]
    public int playerType = 0;

    public GameObject playerCamera;
    public GameObject judgeCamera;

    public GameObject avatarJudge;
    public GameObject avatarPlayer;

    private void Start()
    {
        if(isLocalPlayer == true)
        {
            //enable the camera
            playerCamera.SetActive(true);
            judgeCamera.SetActive(true);
        }
    }

    // when connection established
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("on start server");
        Debug.Log("isserver" + isServer);

        if (isServer)
        {
            Debug.Log("net id" + netId);
        }
        Debug.Log("On start server end");
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        Debug.Log("On start Player");
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (isClientOnly)
        {
            playerType = 1;
        }
       
        Debug.Log("isserver" + isServer);  // is this server machine
        Debug.Log("isserver only " + isServerOnly); // is this machine act as server only
        Debug.Log("is client" + isClient);
        Debug.Log("is client only" + isClientOnly);
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
