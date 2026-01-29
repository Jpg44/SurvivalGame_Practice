using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;

    [Header("Follow")]
    public Vector3 offset = new Vector3(0f, 12f, -12f);
    public float smoothTime = 0.12f;

    [Header("Look")]
    public bool lookAtTarget = true;
    public Vector3 lookOffset = new Vector3(0f, 1.2f, 0f);

    private Vector3 _vel;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref _vel, smoothTime);

        if (lookAtTarget)
        {
            Vector3 lookPoint = target.position + lookOffset;
            transform.rotation = Quaternion.LookRotation((lookPoint - transform.position).normalized, Vector3.up);
        }
    }
}
