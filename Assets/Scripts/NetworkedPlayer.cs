using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedPlayer : NetworkBehaviour
{

    [SyncVar]
    public int playerType = 0;

    public GameObject playerCamera;

    public GameObject avatarPlayer;

    public GameObject leftController;
    public GameObject rightController;

    public GameObject leftIK;
    public GameObject rightIK;
    public GameObject headIK;

    private void Start()
    {
        if(isLocalPlayer == true)
        {
            playerCamera.SetActive(true);       
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
        if (isLocalPlayer == true)
        {
            leftIK.transform.position = leftController.transform.position;
            rightIK.transform.position = rightController.transform.position;
            headIK.transform.position = playerCamera.transform.position;

          
        }

    }

    //Gets executed on the server
    [Command]
    void CmdUpdatePlayerType(int type)
    {
        playerType = type;
    }
}
