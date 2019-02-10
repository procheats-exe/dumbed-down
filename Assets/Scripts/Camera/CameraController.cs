﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _follow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_follow != null)
        {
            transform.position = new Vector3(_follow.position.x, 4, _follow.position.z - 10);
        }
    }
}
