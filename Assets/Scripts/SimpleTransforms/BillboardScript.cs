using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{

    public Camera Camera;

    public Vector3 upVector = Vector3.up;

    void Start()
    {
        Camera = Camera.main;
    }
	
	void Update ()
	{

	    transform.rotation = Camera.transform.rotation;
        transform.Rotate(upVector, 90);
	}
}
