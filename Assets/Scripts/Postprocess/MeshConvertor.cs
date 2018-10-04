using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class MeshConvertor : MonoBehaviour
    {
        public bool isCube = true;

        void Start()
        {
            if (GetComponent<CreateCube>() != null)
            {
                isCube = true;
            }
            else if (GetComponent<CreateCylinder>() != null)
            {
                isCube = false;
            }

            Mesh mesh = GetComponent<MeshFilter>().mesh;

            Vector3[] meshVertices = mesh.vertices;
            int[] meshTriangles = mesh.triangles;

            List<Vector3> newVertices = new List<Vector3>();

            foreach (int triangle in meshTriangles)
            {
                newVertices.Add(meshVertices[triangle]);
            }

            List<int> newTriangles = new List<int>();

            int triCount = 0;

            newVertices.ForEach(x => { newTriangles.Add(triCount++); });

            // Do some calculations...
            mesh.vertices = newVertices.ToArray();
            mesh.triangles = newTriangles.ToArray();

            List<Vector3> oldNormals = new List<Vector3>(CalculateNormals.returnNormals(newVertices));

            if (!isCube)
            {
                int number = newVertices.Count / 2;
                List<Vector3> newNormals = new List<Vector3>();

                foreach (Vector3 vector3 in newVertices.GetRange(newVertices.Count - number, number))
                {
                    Vector3 n = vector3;
                    n.y = 0;
                    Vector3 newNormal = n.normalized;
                    newNormals.Add(newNormal);
                }

                oldNormals.RemoveRange(newVertices.Count - number, number);
                oldNormals.AddRange(newNormals);
            }


//            for (int i = 0; i < newVertices.Count; i++)
//            {
//                Debug.DrawRay(newVertices[i] + transform.position, oldNormals[i].normalized, Color.green, 100f);
//            }

            mesh.normals = oldNormals.ToArray();

#if UNITY_EDITOR
            mesh.uv = Unwrapping.GeneratePerTriangleUV(mesh);
#else
#endif       

            mesh.RecalculateBounds();
            mesh.RecalculateTangents();
        }
    }
}