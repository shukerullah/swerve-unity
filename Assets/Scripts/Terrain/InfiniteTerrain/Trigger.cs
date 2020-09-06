using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTerrain {
  public class Trigger : MonoBehaviour {

    private Transform target;

    private Renderer renderer;

    private float distance;
    private float terrainSize;

    private bool init = false;

    void Start () {
      target = TerrainGenerator.Instance.Target;
      terrainSize = TerrainGenerator.Instance.TerrainSize;
      distance = TerrainGenerator.Instance.TriggerDistance;

      renderer = GetComponent<Renderer> ();
    }

    void OnEnable () {
      if (!init) {
        return;
      }
    }

    void LateUpdate () {
      if (true) {
        if (transform.localPosition.z - target.position.z < -distance) {
          transform.localPosition += Vector3.forward * terrainSize;
        } else if (transform.localPosition.z - target.position.z > distance) {
          transform.localPosition -= Vector3.forward * terrainSize;
        }

        if (transform.localPosition.x - target.position.x < -distance) {
          transform.localPosition += Vector3.right * terrainSize;
        } else if (transform.localPosition.x - target.position.x > distance) {
          transform.localPosition -= Vector3.right * terrainSize;
        }
      }
    }
  }
}