using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 15.0f;

    public bool isGoingRight = false;

    public CameraFollow cameraFollow;

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            isGoingRight = true;
            cameraFollow.focusOnRight = true;
        }

        if (Input.GetMouseButtonUp (0)) {
            isGoingRight = false;
            cameraFollow.focusOnRight = false;
        }

        Speed ();
    }

    void Speed () {
        if (isGoingRight) {
            transform.Translate (Vector3.right * Time.deltaTime * speed);
        } else {
            transform.Translate (Vector3.forward * Time.deltaTime * speed);
        }
    }
}