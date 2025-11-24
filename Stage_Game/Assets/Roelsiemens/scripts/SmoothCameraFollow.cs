using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    #region Variables

    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.2f;

    // Collision settings
    [SerializeField] private float collisionRadius = 0.3f;
    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private float minDistance = 0.5f;

    private Vector3 _currentVelocity = Vector3.zero;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + _offset;
        Vector3 direction = (desiredPos - target.position).normalized;
        float desiredDistance = _offset.magnitude;

        // ----- COLLISION CHECK -----
        if (Physics.SphereCast(
            target.position,
            collisionRadius,
            direction,
            out RaycastHit hit,
            desiredDistance,
            collisionMask))
        {
            float adjustedDistance = Mathf.Max(hit.distance, minDistance);
            desiredPos = target.position + direction * adjustedDistance;
        }

        // ----- SMOOTH FOLLOW -----
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPos,
            ref _currentVelocity,
            smoothTime
        );
    }

    #endregion
}
