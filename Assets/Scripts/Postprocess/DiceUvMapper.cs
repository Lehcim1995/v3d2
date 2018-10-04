using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceUvMapper : MonoBehaviour
{
    private Vector2[] diceMap;

    private Mesh mesh;
    [SerializeField] private Vector2[] uvMapp;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        uvMapp = mesh.uv;

        var third = 1f / 3f;
        var twoThird = 2f / 3f;

        var list = new List<Vector2>();
        //1
        list.AddRange(GetFace(twoThird, third, 0, 2, flipB: true));

        //6
        list.AddRange(GetFace(third, third, 0, 2, flipB: true));

        //2
        list.AddRange(GetFace(0, 0, 0, 2, flipB: true));

        //5
        list.AddRange(GetFace(twoThird, 0, 0, 2, flipB: true));

        //3
        list.AddRange(GetFace(third, 0, 0, 2, flipB: true));

        //4
        list.AddRange(GetFace(0, third, 0, 2, flipB: true));

        mesh.uv = list.ToArray();
    }

    private List<Vector2> GetFace(Vector2 offset, int rotateA, int rotateB,
        bool flip = false,
        bool flipA = false,
        bool flipB = false
    )
    {
        return GetFace(offset.x, offset.y, rotateA, rotateB, flip, flipA, flipB);
    }

    private List<Vector2> GetFace(float offsetX, float offsetY, int rotateA, int rotateB,
        bool flip = false,
        bool flipA = false,
        bool flipB = false
    )
    {
        var third = 1f / 3f;

        var faceA = new List<Vector2>
        {
            new Vector2(0, 0),
            new Vector2(0, third),
            new Vector2(third, 0)
        };

        for (var i = 0; i < rotateA; i++) faceA = faceA.Skip(1).Concat(faceA.Take(1)).ToList();

        if (flipA) faceA.Reverse();

        var faceB = new List<Vector2>
        {
            new Vector2(third, 0),
            new Vector2(third, third),
            new Vector2(0, third)
        };

        for (var i = 0; i < rotateB; i++) faceB = faceB.Skip(1).Concat(faceB.Take(1)).ToList();

        if (flipB) faceB.Reverse();

        var face = new List<Vector2>();

        if (!flip)
        {
            face.AddRange(faceA);
            face.AddRange(faceB);
        }
        else
        {
            face.AddRange(faceB);
            face.AddRange(faceA);
        }

        return face.Select(f =>
        {
            f.x += offsetX;
            f.y += offsetY;
            return f;
        }).ToList();
    }
}