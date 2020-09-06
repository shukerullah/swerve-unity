using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float speed = 2.0f;

    public Transform target;

    public Vector3 offsetLeft;

    public Vector3 offsetRight;

    public bool focusOnRight = false;

    void Update () {
        float interpolation = speed * Time.deltaTime;
        Vector3 targetOffset = offsetLeft;
        if (focusOnRight) {
            targetOffset = offsetRight;
        }

        Vector3 position = transform.position;
        Vector3 desiredPosition = target.position + targetOffset;
        position.z = Mathf.Lerp (position.z, desiredPosition.z, interpolation);
        position.x = Mathf.Lerp (position.x, desiredPosition.x, interpolation);

        transform.position = position;
    }
}