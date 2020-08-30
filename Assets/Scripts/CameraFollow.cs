using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 0.125f;

    public float smoothTurnSpeed = 0.125f;

    public Vector3 offsetLeft;

    public Vector3 offsetRight;

    public Vector3 accidentOffset;

    [HideInInspector]
    public bool focusOnRight = false;

    private Vector3 m_Velocity = Vector3.zero;

    Vector3 m_Offset;

    void Start () {
        m_Offset = offsetLeft;
    }

    void FixedUpdate () {
        Vector3 targetOffset = offsetLeft;

        m_Offset = Vector3.SmoothDamp (m_Offset, targetOffset, ref m_Velocity, smoothTurnSpeed);

        Vector3 desiredPosition = target.position + m_Offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}