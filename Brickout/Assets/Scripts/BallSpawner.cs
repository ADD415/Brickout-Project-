using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class defines a component which can spawn new game objects by creating copies
// of a template game object which already exists in the scene.
class BallSpawner : MonoBehaviour
{
    // This variable should be set in the Inspector to an inactive Text object containing the text to display when the game is over.
    public Text gameOver = null;

    // This variable should be set in the Inspector to an existing ball object within the scene. The template object can, and probably should be an inactive object.
    public Ball ballTemplate = null;

    // The total number of balls to spawn when the game is started. This value can be overridden in the Inspector.
    public int totalBalls = 1;

    // List to keep track of all balls spawned by this script.
    List<Ball> ballList = new List<Ball>();

    // This method is usually run by Unity when the object is created (when the game is first run), but also whenever the object is activated after being inactive.
    void Start()
    {
        // Initialise count to 0, run the loop while count is less than totalBalls and increment count after each iteration of the loop.
        for (int count = 0;
             count < totalBalls;
             count++)
        {
            SpawnBall();
        }
    }

    // Would spawn more balls. (Not implemented).
    void SpawnBall()
    {
        // Clone the template game object.
        Ball ballClone = Instantiate(ballTemplate);

        // Move the new ball clone to the ball spawner's position.
        ballClone.transform.position = transform.position;

        // Activate the new ball clone.
        ballClone.gameObject.SetActive(true);

        // Add the new ball clone to the list of balls.
        ballList.Add(ballClone);
    }

    // Would despawn ball clones.
    public void DespawnBall(Ball ballToDespawn)
    {
        // Remove the ball from the list of balls.
        ballList.Remove(ballToDespawn);

        // Destroy the ball game object.
        Destroy(ballToDespawn.gameObject);

        // Show the game over text if there are no balls left in the list.
        if (ballList.Count == 0)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
}
