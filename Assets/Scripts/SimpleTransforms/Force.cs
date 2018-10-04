using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public Vector3 ForceDirection = Vector3.up;

    public float ForcePower = 100;

    private float _localPower;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(ForceDirection.normalized * ForcePower);
        }
    }
}