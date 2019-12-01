using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetControllerTransform : MonoBehaviour
{
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SetControllerTransform - Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("SetControllerTransform - UPDATE");
        transform.position = controller.transform.position;
    }
}
