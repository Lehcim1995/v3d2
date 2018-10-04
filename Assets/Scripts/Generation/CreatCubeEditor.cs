using UnityEngine;

namespace Assets.Scripts
{
    [ExecuteInEditMode]
    public class CreatCubeEditor : MonoBehaviour {

        private Vector3[] _newVertices;
        private Vector2[] _newUv;
        private int[] _newTriangles;

        [Header("Cube attributes")]
        public float Depth = 5;
        public float Width = 5;
        public float Height = 5;

        public Vector3 center = new Vector3(0, 0, 0);

        public Color CubeColor = Color.red;

        void Update()
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;

            mesh.Clear();

            _newVertices = new Vector3[8];
            // Frontface
            _newVertices[0] = new Vector3(0, 0, 0);
            _newVertices[1] = new Vector3(Width, 0, 0);
            _newVertices[2] = new Vector3(0, Height, 0);
            _newVertices[3] = new Vector3(Width, Height, 0);

            //Backface
            _newVertices[4] = new Vector3(0, 0, Depth);
            _newVertices[5] = new Vector3(Width, 0, Depth);
            _newVertices[6] = new Vector3(0, Height, Depth);
            _newVertices[7] = new Vector3(Width, Height, Depth);

            //        Vector3 v = new Vector3(Width / 2, Height / 2, Depth / 2);

            for (var i = 0; i < _newVertices.Length; i++)
            {
                _newVertices[i] -= center;
            }

            _newTriangles = new[]
            {
                // FRONT
                0, 2, 1,
                2, 3, 1,

                // BACK
                4, 5, 6,
                6, 5, 7,

                //LEFT
                1, 7, 5,
                1, 3, 7,

                // RIGHT
                0, 4, 6,
                0, 6, 2,

                // TOP
                3, 6, 7,
                2, 6, 3,

                //BOTTOM
                0, 1, 4,
                5, 4, 1
            };

            _newUv = new Vector2[_newVertices.Length];

            for (int i = 0; i < _newUv.Length; i++)
            {
                _newUv[i] = new Vector2(_newVertices[i].x, _newVertices[i].z);
            }

            // Do some calculations...
            mesh.vertices = _newVertices;
            mesh.uv = _newUv;
            mesh.triangles = _newTriangles;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            mesh.RecalculateTangents();

            GetComponent<Renderer>().material.color = CubeColor;
        }
    }
}
