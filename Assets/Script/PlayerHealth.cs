using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private Slider _HPBar;
    [SerializeField] private int _maxLife;
    [SerializeField] private int _currentLife;

    [SerializeField] private Collider _collider;
    

    private void Reset()
    {
        _maxLife = 100;
        _currentLife = 100;
    }

    private void Start()
    {
        _HPBar.maxValue = _maxLife;
        _HPBar.value = _currentLife;
    }

    public void Damage(int damage)
    {
        _currentLife -= damage;
        UpdateHealthBar(_currentLife);
        if (_currentLife <= 0)
        {
            //Death
        }
    }
    
    private void UpdateHealthBar(int newValue)
    {
        _HPBar.value = newValue;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            Damage(10);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageZone"))
        {
            Damage(10);
        }
    }
}
