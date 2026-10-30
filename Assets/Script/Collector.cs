using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private HashSet<IHealth> _currentInCollector;

    private void Awake()
    {
        _currentInCollector = new HashSet<IHealth>();
        
        _currentInCollector.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            _currentInCollector.Add(health);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            _currentInCollector.Remove(health);
        }
    }
}
