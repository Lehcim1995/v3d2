using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CreateCylinder : MonoBehaviour
    {
        private Vector3[] _newVertices;
        private Vector2[] _newUv;
        private int[] _newTriangles;

        public float CylinderHeight = 5;
        public float CylinderWidth = 5;
        public int Smoothness = 24;

        public Vector3 Center = new Vector3(0, 0, 0);

        public Color CylinderColor = Color.blue;

        void Start()
        {
            GetComponent<MeshFilter>().mesh = GenerateCylinderMesh(CylinderHeight, CylinderWidth, Smoothness);

            GetComponent<Renderer>().material.color = CylinderColor;
        }

        Mesh GenerateCylinderMesh(float cylinderHeight, float cylinderWidth, int smoothness)
        {
            Mesh mesh = new Mesh();

            // All the vertexis on top and bottom plus center top and bottom
            _newVertices = new Vector3[(smoothness * 2) + 2];

            // Create step
            float step = 360 / (float)smoothness;

            // Create top and bottom circles
            for (int i = 0; i < smoothness; i++)
            {
                float x = Mathf.Cos((i * step) * Mathf.Deg2Rad) * cylinderWidth;
                float y = Mathf.Sin((i * step) * Mathf.Deg2Rad) * cylinderWidth;

                _newVertices[i] = new Vector3(x, cylinderHeight / 2, y);
                _newVertices[i + smoothness] = new Vector3(x, -cylinderHeight / 2, y);
            }

            // Center top and bottom

            int topPosition = (smoothness * 2);
            int bottomPosition = (smoothness * 2) + 1;
            _newVertices[topPosition] = new Vector3(0, cylinderHeight / 2, 0);
            _newVertices[bottomPosition] = new Vector3(0, -cylinderHeight / 2, 0);

            for (var i = 0; i < _newVertices.Length; i++)
            {
                _newVertices[i] -= Center;
            }

            // Were using a  list because i dont know how to calculate the tries on the beginning;
            // I actually do know but im lazy
            List<int> Tris = new List<int>();

            //Creating top and bottom
            for (int i = 0; i < smoothness; i++)
            {
                Tris.Add(i);
                Tris.Add((smoothness * 2));

                if (i + 1 == smoothness)
                {
                    Tris.Add(0);
                }
                else
                {
                    Tris.Add(i + 1);
                }
            }

            for (int i = smoothness; i < smoothness + smoothness; i++)
            {
                if (i + 1 == smoothness + smoothness)
                {
                    Tris.Add(smoothness);
                }
                else
                {
                    Tris.Add(i + 1);
                }

                Tris.Add((smoothness * 2) + 1);
                Tris.Add(i);
            }

            // Creating the sides
            for (int i = 0; i < smoothness; i++)
            {
                // First half
                Tris.Add(i);

                if (smoothness + i + 1 >= smoothness * 2)
                {
                    Tris.Add(smoothness);
                }
                else
                {
                    Tris.Add(smoothness + i + 1);
                }

                Tris.Add(smoothness + i);


                // Second half
                Tris.Add(i);

                if (i + 1 >= smoothness)
                {
                    Tris.Add(0);
                }
                else
                {
                    Tris.Add(i + 1);
                }

                if (smoothness + i + 1 >= smoothness * 2)
                {
                    Tris.Add(smoothness);
                }
                else
                {
                    Tris.Add(smoothness + i + 1);
                }
            }

            _newTriangles = Tris.ToArray();

            _newUv = new Vector2[_newVertices.Length];

            for (int i = 0; i < _newUv.Length; i++)
            {
                _newUv[i] = new Vector2(_newVertices[i].x, _newVertices[i].z);
            }

            mesh.vertices = _newVertices;
            mesh.uv = _newUv;
            mesh.triangles = _newTriangles;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            mesh.RecalculateTangents();

            return mesh;
        }

    }
}