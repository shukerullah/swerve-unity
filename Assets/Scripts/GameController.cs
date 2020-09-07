using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public enum LEVEL { GRASS, DESERT, SNOW }

    public TerrainManager terrainManager;

    public Checkpoints[] checkpoints;

    [HideInInspector]
    public int checkpointIndex = -1;

    private bool m_GameOver = false;
    public bool GameOver {
        get { return m_GameOver; }
        set { m_GameOver = value; }
    }

    static protected GameController s_Instance;
    static public GameController Instance { get { return s_Instance; } }

    private void Awake () {
        if (s_Instance != null && s_Instance != this) {
            Destroy (this.gameObject);
        } else {
            s_Instance = this;
        }
    }

    public Material GetTerrain () {
        return terrainManager.GetTerrain (checkpoints[checkpointIndex].level);
    }

    public int GetRandom (int min, int max) {
        return Random.Range (min, max);
    }

    public float GetRandom (float min, float max) {
        return Random.Range (min, max);
    }
}

[System.Serializable]
public class Checkpoints {
    public int distance = 200;
    public GameController.LEVEL level;
}