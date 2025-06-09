using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, 0f) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
