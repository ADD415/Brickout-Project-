using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioSource BounceSound; // Bounce sound to be used later

    // This method is run by Unity whenever the brick hits something.
    void OnCollisionEnter2D(Collision2D other)
    {
        // Destroys brick object.
        Destroy(gameObject);

        // Plays bounce sound
        BounceSound.Play();

    }
}