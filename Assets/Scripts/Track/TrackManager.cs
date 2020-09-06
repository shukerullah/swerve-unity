using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour {
    public GameObject road;
    public GameObject corner;
    public GameObject checkpoint;

    public int initialRoadSize = 15;

    [Range (0, 1)]
    public float cornerProbability = 0.5f;

    public Vector3 roadRotation = Vector3.zero;
    public Vector3 roadRightRotation = Vector3.zero;

    public Vector3 cornerRotation = Vector3.zero;
    public Vector3 cornerRightRotation = Vector3.zero;

    public Vector3 checkpointRotation = Vector3.zero;
    public Vector3 checkpointRightRotation = Vector3.zero;

    public float roadMargin = 8;
    public float cornerMargin = 8;
    public float checkpointMargin = 24;

    private const int k_StartingRoadPoolSize = 10;
    private const int k_StartingCornerPoolSize = 10;
    private const int k_StartingCheckpointPoolSize = 2;

    private bool m_IsRightTrackNext = false;

    private float m_LastTrackMargin = 0;

    public Vector3 initialTrackPosition = new Vector3 (0, 0, 0);

    private Vector3 m_NextTrackPosition = Vector3.zero;
    public Vector3 NextTrackPosition {
        get { return m_NextTrackPosition; }
        set { m_NextTrackPosition = value; }
    }

    private Vector3 m_InitialTrackPosition = Vector3.zero;

    private int checkpointIndex = -1;

    static protected TrackManager s_Instance;
    static public TrackManager Instance { get { return s_Instance; } }

    private void Awake () {
        if (s_Instance != null && s_Instance != this) {
            Destroy (this.gameObject);
        } else {
            s_Instance = this;
        }

        m_NextTrackPosition = initialTrackPosition;
    }

    void Start () {
        Begin ();
    }

    void Begin () {
        Road.pool = new InfiniteTerrain.Pool (road, k_StartingRoadPoolSize);
        Corner.pool = new InfiniteTerrain.Pool (corner, k_StartingCornerPoolSize);
        Checkpoint.pool = new InfiniteTerrain.Pool (checkpoint, k_StartingCheckpointPoolSize);

        for (int i = 0; i < initialRoadSize; i++) {
            AddNextBlock ();
        }
    }

    public void AddNextBlock () {
        if (IsCheckpointNext ()) {
            AddCheckpoint ();
            return;
        }

        if (IsCornerNext ()) {
            AddCorner ();
            return;
        }

        AddRoad ();
    }

    private bool IsCheckpointNext () {
        if (checkpointIndex < 0) {
            checkpointIndex++;
            return true;
        }

        float distance = Vector3.Distance (m_InitialTrackPosition, m_NextTrackPosition);

        if (distance >= 50) {
            checkpointIndex++;
            m_InitialTrackPosition = m_NextTrackPosition;
            return true;
        }

        return false;
    }

    private void AddCheckpoint () {
        AddBlock (2, checkpointMargin, checkpointRotation, checkpointRightRotation);
    }

    private bool IsCornerNext () {
        float probability = GetRandom (0f, 1f);
        return probability <= cornerProbability;
    }

    private void AddCorner () {
        AddBlock (1, cornerMargin, cornerRotation, cornerRightRotation);
    }

    private void AddRoad () {
        AddBlock (0, roadMargin, roadRotation, roadRightRotation);
    }

    // 0 == Road
    // 1 == Corner
    // 2 == Checkpoint
    private void AddBlock (int type, float trackMargin, Vector3 normalRotation, Vector3 rightRotation) {
        Vector3 position = m_NextTrackPosition;
        Vector3 rotation = m_IsRightTrackNext ? rightRotation : normalRotation;
        float margin = (trackMargin + m_LastTrackMargin) / 2;
        position += (m_IsRightTrackNext ? Vector3.right : Vector3.forward) * margin;

        switch (type) {
            case 1:
                m_IsRightTrackNext = !m_IsRightTrackNext;
                Corner.pool.Get (position, rotation, transform);
                break;
            case 2:
                Checkpoint.pool.Get (position, rotation, transform);
                break;
            default:
                Road.pool.Get (position, rotation, transform);
                break;
        }

        m_NextTrackPosition = position;
        m_LastTrackMargin = trackMargin;
    }

    private float GetRandom (float min, float max) {
        return Mathf.Round (Random.Range (min, max) * 10) / 10;
    }
}