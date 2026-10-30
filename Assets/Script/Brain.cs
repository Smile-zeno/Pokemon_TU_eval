using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Brain : MonoBehaviour
{
    [SerializeField] private InputActionReference _dirInput;
    
    
    [SerializeField] private EntityMouvement _movement;
    
    
    void Start()
    {
        _dirInput.action.started += OnMoveUpdated;
        _dirInput.action.performed += OnMoveUpdated;
        _dirInput.action.canceled += OnMoveCanceled;
    }

    private void OnDestroy()
    {
        _dirInput.action.started -= OnMoveUpdated;
        _dirInput.action.performed -= OnMoveUpdated;
        _dirInput.action.canceled -= OnMoveCanceled;
    }

    private void OnMoveUpdated(InputAction.CallbackContext obj)
    {
        var dir = obj.ReadValue<Vector2>();
        Vector3 pos = new Vector3(dir.x, 0, dir.y);

        _movement.UpdateDirection(pos);
    }
    
    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        _movement.UpdateDirection(Vector3.zero);
    }
}
