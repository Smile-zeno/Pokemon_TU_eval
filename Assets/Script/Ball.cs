using System;
using UnityEngine;
using UnityEngine.Events;
using Slider = UnityEngine.UI.Slider;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    [SerializeField] private UnityEvent _onDeath;
    
    public event Action<int> OnTouchingGround;

    private void Reset()
    {
        _maxHealth = 100f;
        _currentHealth = 100f;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;

        OnTouchingGround += Damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        OnTouchingGround?.Invoke(10);
    }

    private void Damage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0f)
        {
            _onDeath?.Invoke();
            Destroy(transform.parent.gameObject, 3f);
        }
    }
}
