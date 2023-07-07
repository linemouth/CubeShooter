using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float thrust = 25f; // The strength of the cube's motion. The "f" here is needed to signify it as a float, rather than a double.
    public GameObject bulletPrefab; // This is the template bullet that we'll use to spawn all other bullets.
    public float bulletSpeed = 20f; // The muzzle velocity of our bullets.
    public float shootingDelay = 0.5f; // The delay between shots.

    new private Rigidbody rigidbody; // This allows us to interact with our cube's physics.
    private Transform barrel; // This is the transform of the cube that serves as the gun barrel.
    private float nextShootTime = 0; // This is the next time that we're allowed to shoot. It keeps us from shooting too fast.

    // Start() is called on the first frame where the cube is enabled.
    private void Start()
    {
        // We can print a log to prove that we got to this point in the code. This will appear in the Console.
        Debug.Log("Hey! That's tickles!");

        // Find and save the rigidbody so we can use it in Update().
        rigidbody = GetComponent<Rigidbody>();

        // Find the transform of the gun barrel.
        barrel = transform.Find("Barrel");
    }

    // Update() is called once every frame.
    private void FixedUpdate()
    {
        // Get our user inputs
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Store our inputs as a Vector3 and apply some math. This makes it easier to affect our rigidbody.
        Vector3 movementDirection = new Vector3(xInput, 0, zInput);
        movementDirection.Normalize(); // Limit out maximum input to a magnitude of 1 in any direction.

        // Apply forces acting on the rigidbody.
        rigidbody.AddForce(movementDirection * thrust);
    }
    private void Update()
    {
        // Check if we need to shoot a bullet.
        if(Input.GetKey("space") && (Time.time >= nextShootTime))
        {
            nextShootTime = Time.time + shootingDelay; // Calculate the next time we're allowed to shoot.
            GameObject bullet = Instantiate(bulletPrefab, barrel.position, transform.rotation); // Create a clone of the template bullet and put it at the barrel's position.
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // Find the bullet's rigidbody.
            bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed; // Shoot the bullet along its forward direction.
            bulletRigidbody.velocity += rigidbody.velocity; // Add the cube's velocity to conserve bullet momentum.
        }

        // Check to see if the cube fell off the platform.
        if(transform.position.y < -15)
        {
            // Drop the cube above the center platform.
            transform.position = new Vector3(0, 200, 0);

            // Cancel horizontal velocity.
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }
    }
}
