using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTerrain {
    public class TerrainGenerator : MonoBehaviour {

        public Transform target;
        public Transform Target {
            get { return target; }
            set { target = value; }
        }

        public GameObject tile;

        public float tileSize;
        public float TileSize {
            get { return tileSize; }
            set { tileSize = value; }
        }

        private float terrainSize;
        public float TerrainSize {
            get { return terrainSize; }
            set { terrainSize = value; }
        }

        private float terrainCenterPoint;

        [SerializeField]
        private int rows = 5;
        [SerializeField]
        private int cols = 5;

        private int m_StartingPoolSize;

        private float m_triggerDistance;
        public float TriggerDistance {
            get { return m_triggerDistance; }
            set { m_triggerDistance = value; }
        }

        static protected TerrainGenerator s_Instance;
        static public TerrainGenerator Instance { get { return s_Instance; } }

        private void Awake () {
            if (s_Instance != null && s_Instance != this) {
                Destroy (this.gameObject);
            } else {
                s_Instance = this;
            }
        }

        void Start () {
            m_StartingPoolSize = rows * cols;

            terrainSize = tileSize * rows;

            terrainCenterPoint = (terrainSize / 2) - tileSize / 2;

            m_triggerDistance = terrainCenterPoint + tileSize;

            Tile.pool = new Pool (tile, m_StartingPoolSize);

            Reset ();
        }

        void Reset () {

            // x-axis is row here and z-axis is col
            Vector3 pos = Vector3.zero;
            float initPosX = -terrainCenterPoint;
            float initPosZ = -terrainCenterPoint;

            pos.z = initPosZ;
            for (int i = 0; i < rows; i++) {
                pos.x = initPosX;
                for (int j = 0; j < cols; j++) {
                    Tile.pool.Get (pos, Quaternion.identity, transform);
                    pos.x += tileSize;
                }
                pos.z += tileSize;
            }
        }
    }
}