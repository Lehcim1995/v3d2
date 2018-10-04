using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    public Material mat;
    private Vector3 startVertex;
    private Vector3 mousePos;

    private List<Vector3> line = new List<Vector3>();

    void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.Space))
            line.Add(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
    }

    void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINE_STRIP);
        GL.Color(Color.red);
        foreach (var l in line)
        {
            GL.Vertex(l);
        }
        GL.Vertex(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
        GL.End();
        GL.PopMatrix();
    }

    void Example()
    {
        startVertex = new Vector3(0, 0, 0);
        line = new List<Vector3> {startVertex};
    }
}