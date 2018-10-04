using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public Vector3 Angle = Vector3.up;
    public float Speed = 10;

	void Update () {
		gameObject.transform.Rotate(Angle, Speed * Time.deltaTime);
	}
}
