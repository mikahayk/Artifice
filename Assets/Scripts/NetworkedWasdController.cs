﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedWasdController : NetworkBehaviour
{
    [SerializeField]
    float _moveSpeed = 0.1f;

    [SerializeField]
    float _rotateSpeed = 1f;

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer) return;

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) 
            return;

        var move = Vector3.zero;
        var rotate = 0f;

        //keyboard inputs
        if (Input.GetKey(KeyCode.W))
            move += transform.forward;
        if (Input.GetKey(KeyCode.A))
            move += -transform.right;
        if (Input.GetKey(KeyCode.S))
            move += -transform.forward;
        if (Input.GetKey(KeyCode.D))
            move += transform.right;

        if (Input.GetKey(KeyCode.E))
            rotate += 1;
        if (Input.GetKey(KeyCode.Q))
            rotate -= 1;

        var moveSpeed = move * _moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed *= 2;

        //update rotation vector
        transform.Rotate(Vector3.up, _rotateSpeed * rotate);
        //updating position vector
        transform.position += moveSpeed;
    }
}
