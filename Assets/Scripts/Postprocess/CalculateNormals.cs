using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateNormals : MonoBehaviour {

    public static Vector3[] returnNormals(List<Vector3> vertexesList)
    {
        List<Vector3> normals = new List<Vector3>();

        if (vertexesList.Count % 3 != 0)
        {
            return normals.ToArray();
        }


        for (int i = 0; i < vertexesList.Count; i+=3)
        {
            Vector3 u = vertexesList[i + 1] - vertexesList[i];

            Vector3 v = vertexesList[i + 2] - vertexesList[i];

            Vector3 normal = new Vector3();

            
//            normal.x = (u.y * v.z) - (u.z * v.y);
//            normal.y = (u.z * v.x) - (u.x * v.z);
//            normal.z = (u.x * v.y) - (u.y * v.x);

            normal = Vector3.Cross(u, v);

            //normal.Normalize

            normals.Add(normal);
            normals.Add(normal);
            normals.Add(normal);
        }

        return normals.ToArray();
    }
}
