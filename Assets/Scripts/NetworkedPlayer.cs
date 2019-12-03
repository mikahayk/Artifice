using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedPlayer : NetworkBehaviour
{

    private NetworkedGameManager gameManager;
    
    

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



    public GameObject bot1Parent;
    public GameObject bot2Parent;


    private GameObject bot1;
    private GameObject bot2;
    private GameObject spotlight1;
    private GameObject spotlight2;

    private string[] allAvatarTypes = { "bot1", "bot2", "player" };

    public GameObject[] allAvatars;

    [SyncVar]
    private string avatar_1_type;

    [SyncVar]
    private string avatar_2_type;

    [SyncVar]
    private string avatar_3_type;

    [SyncVar]
    private bool isRoundOver = false;




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
        Debug.Log("NetworkedPlayer - START()");
        gameManager = FindObjectOfType<NetworkedGameManager>();
        
        //myController.Play();


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

        // Enable UI directions for JUDGE
        judgeUI.SetActive(true);


        // Randomize three avatar positions by shuffling allAvatarTypes array
        Shuffle(allAvatarTypes);

        // Spawn avatars to the scene
        SetAvatars();

        Debug.Log("ALL AVATARS ON CLIENT OnStartServer ::::::");

        Play();






        Debug.Log("On start server end");
     }

     public override void OnStartLocalPlayer()
     {
        base.OnStartLocalPlayer();

        playerCamera.SetActive(true);

        // Enable UI directions for ACTOR
        judgeUI.SetActive(false);
        Instantiate(actorUI);

        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(-5, 0, 8); // Left
        positions[1] = new Vector3(-1, 0, 8); // Center
        positions[2] = new Vector3(3, 0, 8);  // Right



        Debug.Log("ALL AVATARS ON CLIENT OnStartLocalPlayer ::::::");

        if (avatar_1_type == "bot1")
            Instantiate(bot1Parent, positions[0], Quaternion.identity);

        if (avatar_1_type == "bot2")
            Instantiate(bot2Parent, positions[0], Quaternion.identity);

        if (avatar_2_type == "bot1")
            Instantiate(bot1Parent, positions[1], Quaternion.identity);

        if (avatar_2_type == "bot2")
            Instantiate(bot2Parent, positions[1], Quaternion.identity);


        if (avatar_3_type == "bot1")
            Instantiate(bot1Parent, positions[2], Quaternion.identity);

        if (avatar_3_type == "bot2")
            Instantiate(bot2Parent, positions[2], Quaternion.identity);



        // Start bots animations
        Play();




        Debug.Log("On start Player");
     }

     public override void OnStartClient()
     {
        
        base.OnStartClient();
        Debug.Log("On start server end");


        Debug.Log("isserver" + isServer);  // is this server machine
        Debug.Log("isserver only " + isServerOnly); // is this machine act as server only
        Debug.Log("is client" + isClient);
        Debug.Log("is client only" + isClientOnly);
     }






    public void Play()
    {
        isRoundOver = false;

        GameObject.Find("Countdown").GetComponent<CountdownController>().enabled = true;

        spotlight1 = bot1Parent.transform.Find("Spotlight1").gameObject;
        spotlight2 = bot2Parent.transform.Find("Spotlight2").gameObject;

        // Enable the spotlights
        spotlight1.SetActive(true);
        spotlight2.SetActive(true);


        foreach(var bot in GameObject.FindGameObjectsWithTag("Bot")) {
            bot.GetComponent<Animator>().enabled = true;
        }

    }

    public void Pause()
    {
        Debug.Log("PAUSE");


        // Stop animating the bots
        foreach (var bot in GameObject.FindGameObjectsWithTag("Bot"))
        {
            bot.GetComponent<Animator>().enabled = false;
        }


        isRoundOver = true;
    }



    private void Update()
    {
        if (isLocalPlayer == true)
        {
            if(!isRoundOver)
            {
                leftIK.transform.position = leftController.transform.position;
                rightIK.transform.position = rightController.transform.position;
                headIK.transform.position = playerCamera.transform.position;
            }
            
        }

    }


    private void SetAvatars()
    {
        Debug.Log("NetworkedPlayer - SetAvatars()");

        
        allAvatars = new GameObject[3];
        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(-5, 0, 8); // Left
        positions[1] = new Vector3(-1, 0, 8); // Center
        positions[2] = new Vector3(3, 0, 8);  // Right


        for (int i = 0; i < 3; i++)
        {
            if (allAvatarTypes[i] == "bot1")
            {
                allAvatars[i] = bot1Parent;
                NetworkServer.Spawn(Instantiate(bot1Parent, positions[i], Quaternion.identity));
            }

            if (allAvatarTypes[i] == "bot2")
            {
                allAvatars[i] = bot2Parent;
                NetworkServer.Spawn(Instantiate(bot2Parent, positions[i], Quaternion.identity));
            }

            if (allAvatarTypes[i] == "player")
            {
                transform.position = positions[i];
            }
 
        }

        avatar_1_type = allAvatarTypes[0];
        avatar_2_type = allAvatarTypes[1];
        avatar_3_type = allAvatarTypes[2];
       

        /*
        foreach (var avatar in allAvatars)
        {
            Debug.Log(avatar);
        }
        */

    }

    private void Shuffle(string[] texts)
    {
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
