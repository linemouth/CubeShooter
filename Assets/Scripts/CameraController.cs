using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject subject; // This is the object that the camera will follow.

    private float angle = 45; // This is the up/down angle at which the camera looks down at the subject.
    private float azimuth = 0; // This is the left/right angle at which the camera looks around the subject.
    private float distance = 15; // This is how far the camera is from the subject.
    private float zoomScale = 5; // This is how sensitive the zoom is.

    private void Update()
    {
        // First, get the user inputs. This will allow us to use the mouse to adjust the camera position.
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomScale, 5, 30);
        angle = Mathf.Clamp(angle - Input.GetAxis("Mouse Y"), 15, 90);
        //azimuth = Mathf.Repeat(azimuth + Input.GetAxis("Mouse X"), 360); // The problem is, this makes the controls rotate, too.

        // Start with the subject's position.
        Vector3 subjectPosition = subject.transform.position;

        // Make a vector to offset the position of the camera.
        // This should just be backwards by the current distance.
        Vector3 offset = new Vector3(0, 0, -distance);

        // Now, let's calculate the rotation based on the angle, convert it to Quaternion, and apply it.
        Quaternion rotation = Quaternion.Euler(new Vector3(angle, azimuth, 0));
        transform.rotation = rotation;

        // Now, we rotate the offset vector down by the current angle.
        // We do this by multiplying the rotation as a Quaternion and the offset vector.
        offset = rotation * offset;

        // Set the camera position to the subject's position plus the offset.
        transform.position = subjectPosition + offset;
    }
}
