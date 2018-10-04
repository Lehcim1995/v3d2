using UnityEngine;

namespace Assets.Scripts
{
    public class CreateCube : MonoBehaviour
    {
        private Vector3[] _newVertices;
        private Vector2[] _newUv;
        private int[] _newTriangles;

        [Header("Cube attributes")] public float Depth = 5;
        public float Width = 5;
        public float Height = 5;

        public Vector3 Center = new Vector3(0, 0, 0);

        public Color CubeColor = Color.red;

        void Start()
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

            for (var i = 0; i < _newVertices.Length; i++)
            {
                _newVertices[i] -= Center;
            }

            _newTriangles = new[]
            {
                // FRONT
                0, 2, 1,
                3, 1, 2,

                // BACK
                6, 4, 7,
                5, 7, 4,

                //LEFT
                4, 6, 0,
                2, 0, 6,

                // RIGHT
                1, 3, 5,
                7, 5, 3,

                // TOP
                2, 6, 3,
                7, 3, 6,

                //BOTTOM
                4, 0, 5,
                1, 5, 0
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