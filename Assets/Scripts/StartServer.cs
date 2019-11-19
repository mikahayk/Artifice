using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartServer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetupServer();
    }

    public void SetupServer()
    {
        NetworkServer.Listen(7777);

    }
}