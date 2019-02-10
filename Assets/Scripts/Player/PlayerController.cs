using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    [SerializeField]
    private float _rotateSpeed = 0.1f;

    [SerializeField]
    private float _jumpSpeed = 8.0f;

    [SerializeField]
    private float _gravity = 20.0f;

    private Vector3 moveDirectrion;
    private CharacterController _characterController;

    void Awake()
    {
        moveDirectrion = Vector3.zero;
        _characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    
    void FixedUpdate()
    {
        if(_characterController.isGrounded)
        {
            moveDirectrion = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirectrion = transform.TransformDirection(moveDirectrion);
            moveDirectrion *= _speed;

            if (Input.GetButton("Jump"))
                moveDirectrion.y = _jumpSpeed;
        }

        moveDirectrion.y -= _gravity * Time.deltaTime;
        _characterController.Move(moveDirectrion * Time.deltaTime);

        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        if (Input.GetAxis("Mouse X") < 0)
            transform.Rotate(Vector3.up * -_speed);
        if (Input.GetAxis("Mouse X") > 0)
            transform.Rotate(Vector3.up * _speed);
    }
}
