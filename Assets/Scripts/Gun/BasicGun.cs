using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [SerializeField]
    private float _damage = 10.0f;

    [SerializeField]
    private float _range = 100f;

    [SerializeField]
    private float _fireRate = 15f;

    [SerializeField]
    private int _totalAmmo = 90;

    [SerializeField]
    private int _magAmmo = 30;

    private int _currentTotalAmmo;
    private int _currentMagAmmo;

    [SerializeField]
    private Camera _camera;

    private float nextTimeToFire = 0f;

    void Awake()
    {
        _currentTotalAmmo = _totalAmmo;
        _currentMagAmmo = _magAmmo;
    }
    
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / _fireRate;
            if (_currentMagAmmo > 0)
                Shoot();
            else
                Reload();
        }
    }

    void Shoot()
    {
        _currentMagAmmo -= 1;
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
            var target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamange(_damage);
            }
        }
    }

    void Reload()
    {
        Debug.Log("Reloading");
        if (_currentMagAmmo < _magAmmo && _currentTotalAmmo > 0)
        {
            var totalAmmo = _currentMagAmmo + _currentTotalAmmo;

            if (totalAmmo > _magAmmo)
            {
                _currentMagAmmo = _magAmmo;
                _currentTotalAmmo = totalAmmo - _currentMagAmmo;
            }
            else
            {
                _currentMagAmmo = totalAmmo;
                _currentTotalAmmo -= _currentMagAmmo;
            }
        }
    }
}
