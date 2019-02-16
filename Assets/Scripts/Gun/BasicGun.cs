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
    private Camera _camera;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
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
}
