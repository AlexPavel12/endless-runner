using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Range(0.01f, 1.0f)]
    public float smoothSpeed;

    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(0, 8, player.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        if (player != null)
        {
            transform.position = smoothedPosition;
        }
    }
}
