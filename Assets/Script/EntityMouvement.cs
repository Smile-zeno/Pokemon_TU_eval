using System;
using UnityEngine;

public class EntityMouvement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;

    private Vector3 _direction;
    
    private void Reset()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _speed = 100f;
    }

    public void UpdateDirection(Vector3 dir)
    {
        _direction = dir.normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + _direction * (_speed * Time.fixedDeltaTime));
        // _rb.AddForce(_direction * _speed);
    }
}
