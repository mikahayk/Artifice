using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class JudgeCameraController : NetworkBehaviour
{
    public GameObject judgeCamera;

    // Start is called before the first frame update
    void Start()
    {
        
        if (isServerOnly)
        {
            judgeCamera.SetActive(true);
        } else
        {
            judgeCamera.SetActive(false);
        }
    }

    public override void OnStartServer()
    {

    }

}
