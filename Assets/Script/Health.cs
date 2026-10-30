using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth
{
    [BoxGroup("PV")]
    [SerializeField] private int _maxLife;
    [BoxGroup("PV")]
    [ShowNonSerializedField] private int _currentLife;

    [ShowAssetPreview] [SerializeField] private GameObject prefab;

    [SerializeField] private UnityEvent _onDamage;
    

    private void Reset()
    {
        _maxLife = 100;
        _currentLife = 100;
    }

    private void OnValidate()
    {
        if (_maxLife <= 0)
        {
            Debug.LogWarning("<color=red>No no no !</color>");
            _maxLife = 100;
        }

        if (_currentLife > _maxLife || _currentLife <= 0)
        {
            Debug.LogWarning("<color=red>T</color><color=orange>h</color><color=yellow>e</color> <color=green>c</color><color=blue>u</color><color=white>r</color><color=purple>r</color><color=red>e</color><color=orange>n</color><color=yellow>t</color> <color=green>H</color><color=blue>P</color> <color=white>i</color><color=purple>s</color> <color=red>h</color><color=orange>i</color><color=yellow>g</color><color=green>h</color><color=blue>e</color><color=white>r</color> <color=purple>t</color><color=red>h</color><color=orange>a</color><color=yellow>n</color> <color=green>t</color><color=blue>h</color><color=white>e</color> <color=purple>m</color><color=red>a</color><color=orange>x</color> <color=yellow>H</color><color=green>P</color>");
            _currentLife = _maxLife;
        }
    }

    public void Regen(int value)
    {
        _currentLife += value;
        if (_currentLife > _maxLife)
        {
            _currentLife = _maxLife;
        }
    }
    
    public void Damage(int value)
    {
        _currentLife -= value;
        _onDamage?.Invoke();
        if (_currentLife <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        //Died
        return;
    }

    [Button]
    void DamageOf10()
    {
        Damage(10);
    }
}
