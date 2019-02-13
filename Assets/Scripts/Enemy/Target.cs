using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float _health;

    public void TakeDamange(float damange)
    {
        _health -= damange;

        if (_health <= 0)
            Destroy(gameObject);
    }
}
