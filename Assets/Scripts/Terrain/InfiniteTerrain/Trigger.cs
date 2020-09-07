using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTerrain {
  public class Trigger : MonoBehaviour {

    private Transform target;

    private Renderer renderer;

    private Decoration decoration;

    private float distance;
    private float terrainSize;

    private bool init = false;

    void Start () {
      target = TerrainGenerator.Instance.Target;
      terrainSize = TerrainGenerator.Instance.TerrainSize;
      distance = TerrainGenerator.Instance.TriggerDistance;

      renderer = GetComponent<Renderer> ();
      decoration = GetComponent<Decoration> ();
    }

    void OnEnable () {
      if (!init) {
        return;
      }

      SetDecoration ();
    }

    void LateUpdate () {
      if (true) {
        if (transform.localPosition.z - target.position.z < -distance) {
          transform.localPosition += Vector3.forward * terrainSize;
          SetMaterial ();
          SetDecoration ();
        } else if (transform.localPosition.z - target.position.z > distance) {
          transform.localPosition -= Vector3.forward * terrainSize;
          SetMaterial ();
          SetDecoration ();
        }

        if (transform.localPosition.x - target.position.x < -distance) {
          transform.localPosition += Vector3.right * terrainSize;
          SetMaterial ();
          SetDecoration ();
        } else if (transform.localPosition.x - target.position.x > distance) {
          transform.localPosition -= Vector3.right * terrainSize;
          SetMaterial ();
          SetDecoration ();
        }
      }
    }

    void SetMaterial () {
      init = true;
      Material[] mats = renderer.materials;
      mats[0] = GameController.Instance.GetTerrain ();
      renderer.materials = mats;
    }

    void SetDecoration () {
      decoration.SetDecoration (renderer.materials[0].name);
    }
  }
}