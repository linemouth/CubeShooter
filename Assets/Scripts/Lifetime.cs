using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    // This sets the default lifetime, but we can modify it in the editor.
    public float lifetime = 10;

    private void Start()
    {
        // Use the Destroy() function's delay to serve as an expiration time.
        Destroy(gameObject, lifetime);
    }
}
