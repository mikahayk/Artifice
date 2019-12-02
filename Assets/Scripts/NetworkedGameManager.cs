
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedGameManager : MonoBehaviour
{
    public GameObject bot1Parent;
    public GameObject bot2Parent;
    public GameObject botPlayer;

    private GameObject bot1;
    private GameObject bot2;


    private string[] allAvatarTypes = { "bot1", "bot2", "player" };
    private GameObject[] allAvatars;


    public void Start()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

        Shuffle(allAvatarTypes);
        SetAvatarPositions();


    }

    private void SetAvatarPositions()
    {

        Vector3 leftAvatarTransform = new Vector3(-5, 0, 8);
        Vector3 centerAvatarTransform = new Vector3(-1, 0, 8);
        Vector3 rightAvatarTransform = new Vector3(3, 0, 8);


        allAvatars = new GameObject[3];


        for (int i = 0; i < 3; i++)
        {
            if (allAvatarTypes[i] == "bot1")
                allAvatars[i] = bot1Parent;

            if (allAvatarTypes[i] == "bot2")
                allAvatars[i] = bot2Parent;

            if (allAvatarTypes[i] == "player")
                allAvatars[i] = botPlayer;
        }

        allAvatars[0].transform.position = leftAvatarTransform;
        allAvatars[1].transform.position = centerAvatarTransform;
        allAvatars[2].transform.position = rightAvatarTransform;


    }



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

        bot1 = bot1Parent.transform.Find("Bot").gameObject;
        bot2 = bot2Parent.transform.Find("Bot").gameObject;

        //// Enable the bots
        bot1.SetActive(true);
        bot2.SetActive(true);

        //// Start animating the bots
        bot1.GetComponent<Animator>().enabled = true;
        bot2.GetComponent<Animator>().enabled = true;

        //// Enable actor controllers
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
