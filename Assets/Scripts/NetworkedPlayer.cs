using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedPlayer : NetworkBehaviour
{

    private NetworkedGameManager myController;
    
    

    [SyncVar]
    public int playerType = 0;

    public GameObject playerCamera;
    public GameObject avatarPlayer;

    public GameObject leftController;
    public GameObject rightController;

    public GameObject leftIK;
    public GameObject rightIK;
    public GameObject headIK;

    public GameObject judgeUI;
    public GameObject actorUI;


    /*
        CLIENT = ACTOR
        SERVER = JUDGE
    */

    private bool IsJudge()
    {
        return isServer ? true : false;
    }

    private bool IsActor()
    {
        return isClient ? true : false;
    }



    private void Start()
    {
        myController = FindObjectOfType<NetworkedGameManager>();
        myController.Play();

        if (isLocalPlayer == true)
        {
           
        }



    }

     // when connection established
     public override void OnStartServer()
     {
        /* JUDGE */
        base.OnStartServer();
        Debug.Log("on start server");
        Debug.Log("isserver" + isServer);

        if (isServer)
        {
            Debug.Log("net id" + netId);
        }



        // Enable UI directions
        actorUI.SetActive(false);
        judgeUI.SetActive(true);



        Debug.Log("On start server end");
     }

     public override void OnStartLocalPlayer()
     {
        base.OnStartLocalPlayer();

        playerCamera.SetActive(true);


        Debug.Log("On start Player");
     }

     public override void OnStartClient()
     {
        /* ACTOR */
        base.OnStartClient();


        // Enable UI directions
        judgeUI.SetActive(false);
        actorUI.SetActive(true);


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
