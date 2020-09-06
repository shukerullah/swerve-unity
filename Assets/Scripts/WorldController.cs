using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {
    public Transform[] blocks;
    public int checkpointBlockIndex = 0;

    public Vector3 m_NextBlockPosition = Vector3.zero;

    private int m_CurrentBlockIndex = 0;
    private int m_PreviousBlockIndex = 0;

    private bool m_IsCheckpointNext = true;

    private void Start () {
        Begin ();
    }

    private void Begin () {
        Reset ();
        AddBlock ();
    }

    private void Reset () {
        m_NextBlockPosition = Vector3.zero;
        int m_CurrentBlockIndex = 0;
        int m_PreviousBlockIndex = 0;
        bool m_IsCheckpointNext = true;

        for (int i = 0; i < blocks.Length; i++) {
            // TODO: RESET EACH BLOCK POSITION
        }
    }

    private void AddBlock () {
        int index = GetNextBlockIndex ();
        Transform block = blocks[index];
        block.position = new Vector3 (0, 0, 0);
        print (block);
    }

    private int GetNextBlockIndex () {
        int index = checkpointBlockIndex;

        if (!m_IsCheckpointNext) {
            do {
                index = GetRandom (0, blocks.Length);
            } while (index == checkpointBlockIndex || index == m_CurrentBlockIndex || index == m_PreviousBlockIndex);
        }

        m_PreviousBlockIndex = m_CurrentBlockIndex;
        m_CurrentBlockIndex = index;

        return index;
    }

    private int GetRandom (int min, int max) {
        return Random.Range (min, max);
    }
}