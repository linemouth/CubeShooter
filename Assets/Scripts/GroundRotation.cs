using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotation : MonoBehaviour
{
    private void Start()
    {
        // Apply some torque to the rigidbody to start the ground rotating.
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = Vector3.zero; // Ensure the center stays put.
        rigidbody.angularVelocity = new Vector3(0, 0.1f, 0); // Start the ground rotating.
    }
}
