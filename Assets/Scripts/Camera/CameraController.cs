using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 60.0f;

    [SerializeField]
    private Transform _follow;

    [SerializeField]
    private float _offSet = 10.0f;
    
    private Transform _camTransform;

    private float _currentX = 0.0f;
    private float _currentY = 0.0f;
    
    void Start()
    {
        _camTransform = transform;
    }

    void Update()
    {
        _currentX += Input.GetAxis("Mouse X");
        _currentY += Input.GetAxis("Mouse Y");

        _currentY = Mathf.Clamp(_currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    
    void LateUpdate()
    {
        if(_follow != null)
        {
            Vector3 direction = new Vector3(0, 0, -_offSet);
            Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
            _camTransform.position = _follow.position + rotation * direction;
            _camTransform.LookAt(_follow.position);
        }
    }
}
