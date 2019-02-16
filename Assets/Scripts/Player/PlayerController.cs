using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    [SerializeField]
    private float _rotateSpeed = 1.0f;

    [SerializeField]
    private float _jumpSpeed = 8.0f;

    [SerializeField]
    private float _gravity = 20.0f;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _sensitivity = 5.0f;

    [SerializeField]
    private float _lookSmooth = 2.0f;

    private Vector2 _lookDirection;
    private Vector3 moveDirectrion;
    private CharacterController _characterController;
    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        ControlMovement();
        //ControlLookAround();
    }

    void ControlMovement()
    {
        float xAxisMove = Input.GetAxis("Horizontal");
        float zAxisMove = Input.GetAxis("Vertical");

        transform.Translate(xAxisMove * _speed * Time.deltaTime, 0, zAxisMove * _speed * Time.deltaTime);
    }

    void ControlLookAround()
    {
        Vector2 mouseDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        mouseDir = Vector2.Scale(mouseDir, new Vector2(_sensitivity, _sensitivity));

        Vector2 lookDelta = new Vector2();
        lookDelta.x = Mathf.Lerp(lookDelta.x, mouseDir.x, 1.0f / _lookSmooth);
        lookDelta.y = Mathf.Lerp(lookDelta.y, mouseDir.y, 1.0f / _lookSmooth);
        _lookDirection += lookDelta;

        _lookDirection.y = Mathf.Clamp(_lookDirection.y, -75.0f, 75.0f);

        _camera.transform.localRotation = Quaternion.AngleAxis(-_lookDirection.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(-_lookDirection.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(_lookDirection.x, transform.up);
    }
}
