using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // This event is triggered when a collider enters another collider that is set to be a trigger.
    private void OnTriggerEnter(Collider collider)
    {
        // We need to check to see that the collider that entered was the player cube.
        if(collider.name == "Cube")
        {
            Debug.Log("You win!"); // Congratulations!
            GetComponent<ParticleSystem>().Play(); // Let's celebrate with some sparkles!
        }
    }
}
