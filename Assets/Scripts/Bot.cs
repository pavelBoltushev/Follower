using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bot : MonoBehaviour
{
    [SerializeField] private CharacterController _playerController;
    [SerializeField] private float _velocityReducingCoeficient;
    [SerializeField] private float _minDistance;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, _playerController.transform.position) > _minDistance)
        {
            Vector3 _playerFollowingVector = (_playerController.transform.position - transform.position).normalized * _playerController.velocity.magnitude * _velocityReducingCoeficient;
            _rigidbody.velocity = new Vector3(_playerFollowingVector.x, _rigidbody.velocity.y, _playerFollowingVector.z);
        }
    }
}
