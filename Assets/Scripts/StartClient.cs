using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartClient : NetworkBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SetupClient();
    }

    // Create a client and connect to the server port  
    public void SetupClient()
    {
        NetworkClient.RegisterHandler<ConnectMessage>(OnConnected);
        NetworkClient.Connect("localhost");

    }

    // client function
    public void OnConnected(NetworkConnection conn, ConnectMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
}