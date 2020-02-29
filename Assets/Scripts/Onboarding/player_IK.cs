using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_IK : MonoBehaviour
{

    public GameObject leftIK;
    public GameObject rightIK;
    public GameObject headIK;

    public GameObject leftController;
    public GameObject rightController;

    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	void Update()
	{
	    leftIK.transform.position = leftController.transform.position;
	    rightIK.transform.position = rightController.transform.position;
	    headIK.transform.position = playerCamera.transform.position;

	}
}
