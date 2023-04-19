using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class FollowerDronePropeller : MonoBehaviour
{
    [Header("Propeller Properties")]
    [SerializeField] private Transform propeller;
    [SerializeField] private float propRotSpeed = 200f;

    void FixedUpdate()
    {

        HandlePropellers();
    }

    void HandlePropellers()
    {
        if (!propeller)
        {
            return;
        }

        propeller.Rotate(Vector3.up, propRotSpeed);
    }

    /*public void Hover(Rigidbody rb)
    {
        Vector3 upVec = transform.up;
        upVec.x = 0f;
        upVec.z = 0f;
        float diff = 1 - upVec.magnitude;
        float finalDiff = Physics.gravity.magnitude * diff;

        Vector3 engineForce = Vector3.zero;

        float upForce = ((rb.mass * Physics.gravity.magnitude) + finalDiff) / 4f;
        engineForce = transform.up * upForce;

        rb.AddForce(engineForce, ForceMode.Force);

    }*/


}