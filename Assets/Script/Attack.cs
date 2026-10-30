using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private float _damageDeal;
    private bool _isAttacking;

    private void Start()
    {
        _isAttacking = false;
    }

    public void DoAttack()
    {
        
    }
}
