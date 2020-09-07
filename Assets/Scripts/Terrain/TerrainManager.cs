using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
    public Material[] grass;
    [Range (0, 1)] public float[] grassRatio;

    public Material[] desert;
    [Range (0, 1)] public float[] desertRatio;

    public Material[] snow;
    [Range (0, 1)] public float[] snowRatio;

    public Material GetTerrain (GameController.LEVEL level) {
        switch (level) {
            case GameController.LEVEL.DESERT:
                return GetDesert ();
            case GameController.LEVEL.SNOW:
                return GetSnow ();
            default:
                return GetGrass ();
        }
    }

    private Material GetGrass () {
        return GetMat (grassRatio, grass);
    }

    private Material GetDesert () {
        return GetMat (desertRatio, desert);
    }

    private Material GetSnow () {
        return GetMat (snowRatio, snow);
    }

    private Material GetMat (float[] ratios, Material[] mats) {
        float ratio = GameController.Instance.GetRandom (0, 1f);
        int index = 0;
        for (int i = ratios.Length - 1; i >= 0; i--) {
            if (ratio <= ratios[i]) {
                index = i;
                break;
            }
        }
        return mats[index];
    }
}