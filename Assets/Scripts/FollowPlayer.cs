﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothCamera = 0.125f;
    public Vector3 offset;

    void FixedUpdate(){
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothCamera * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
