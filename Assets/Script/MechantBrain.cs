using UnityEngine;

public class MechantBrain : MonoBehaviour
{
    [SerializeField] private EntityMouvement _move;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _stopDistance;
    

    void Update()
    {
        var mePosition = transform.position;
        var playerPosition = _player.transform.position;

        Vector3 directionToPlayer = playerPosition - mePosition;


        if (directionToPlayer.magnitude > _stopDistance)
        {
            _move.UpdateDirection(directionToPlayer);
        }
        else
        {
            _move.UpdateDirection(Vector3.zero);
        }
    }
}
