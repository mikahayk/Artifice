using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{

    public GameObject roomCamera;
    public GameObject playerCamera;
    public GameObject player;

    void Switch()
    {
        roomCamera.SetActive(false);
        playerCamera.SetActive(true);
        player.SetActive(true);
}
}
