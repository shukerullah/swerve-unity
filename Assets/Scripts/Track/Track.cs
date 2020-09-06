using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public enum TYPE { ROAD, CORNER, CHECKPOINT }

    public float distance = 10;

    public TYPE trackType;

    private Transform m_Camera;

    void Awake () {
        m_Camera = Camera.main.transform;
    }

    void LateUpdate () {
        if (m_Camera.position.z - transform.position.z > distance || m_Camera.position.x - transform.position.x > distance) {
            TrackManager.Instance.AddNextBlock ();
            switch (trackType) {
                case TYPE.CHECKPOINT:
                    Checkpoint.pool.Free (gameObject);
                    break;
                case TYPE.ROAD:
                    Road.pool.Free (gameObject);
                    break;
                default:
                    Corner.pool.Free (gameObject);
                    break;
            }
        }
    }
}