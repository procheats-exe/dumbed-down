using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _follow;

    [SerializeField]
    private float speedH = 2.0f;
    [SerializeField]
    private float speedV = 2.0f;

    private float _yaw;
    private float _pitch;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _yaw += speedH * Input.GetAxis("Mouse X");
        _pitch -= speedV * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);

        if (_follow != null)
        {
            transform.position = new Vector3(_follow.position.x, 4, _follow.position.z - 10);
        }
    }
}
