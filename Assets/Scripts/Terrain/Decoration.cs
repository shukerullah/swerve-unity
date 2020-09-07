using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour {
    public GameObject[] green;
    public GameObject[] desert;
    public GameObject[] snow;

    private GameObject obj;

    public void SetDecoration (string name) {
        if (obj) {
            obj.SetActive (false);
        }

        switch (name) {
            case "Desert 1 (Instance)":
            case "Desert 2 (Instance)":
                SetDesert ();
                break;
            case "Snow 1 (Instance)":
                SetSnow ();
                break;
            default:
                SetGreen ();
                break;
        }
    }

    void SetGreen () {
        obj = green[GameController.Instance.GetRandom (0, green.Length)];
        EnableDec ();
    }

    void SetDesert () {
        obj = desert[GameController.Instance.GetRandom (0, desert.Length)];
        EnableDec ();
    }

    void SetSnow () {
        obj = snow[GameController.Instance.GetRandom (0, snow.Length)];
        EnableDec ();
    }

    void EnableDec () {
        obj.transform.localPosition = new Vector3 (GameController.Instance.GetRandom (-4f, 4f), 0, GameController.Instance.GetRandom (-4f, 4f));
        obj.SetActive (true);
    }
}