using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour {

    public bool disableOnAwake = false;

    public bool disableOnStart = false;

    public bool disableOnTriggerEnter = false;

    void Awake () {
        Disable (disableOnAwake);
    }

    void Start () {
        Disable (disableOnStart);
    }

    void OnTriggerEnter (Collider other) {
        Disable (disableOnTriggerEnter);
    }

    private void Disable (bool flag) {
        if (flag) {
            gameObject.SetActive (false);
        }
    }
}