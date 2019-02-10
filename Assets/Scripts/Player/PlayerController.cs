using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        var front = Input.GetButton("Front");
        var back = Input.GetButton("Back");
        var right = Input.GetButton("Right");
        var left = Input.GetButton("Left");

        if (front)
            transform.position += Vector3.forward * _speed * Time.deltaTime;

        if (back)
            transform.position += Vector3.back * _speed * Time.deltaTime;

        if (right)
            transform.position += Vector3.right * _speed * Time.deltaTime;

        if (left)
            transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
