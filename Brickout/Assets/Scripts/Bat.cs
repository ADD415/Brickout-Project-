using UnityEngine;
using UnityEngine.UI;

class Bat : MonoBehaviour
{
    public Text livesLabel = null; // Used for live system.
    int lives = 3; // Used for calculating lives.
    public KeyCode moveLeftKey = KeyCode.LeftArrow; // Left arrow = move left.
    public KeyCode moveRightKey = KeyCode.RightArrow; // Right arrow = move right.
    bool canMoveLeft = true; // Bat can move left, allows later code for moving left to be used.
    bool canMoveRight = true; // Bat can move right, allows later code for moving right to be used.
    public float speed = 0.2f; // Bat speed, allows later code using speed to be used.
    float direction = 0.0f; // Bat direction, allows later code using direction to be used.

    // For substracting life count
    public void Decreaselives(int points)
    {
        lives -= points;
        livesLabel.text = lives.ToString();
    }

    // Used for bat movement, FixedUpdate insures ideal movement
    void FixedUpdate()
    {
        // Bat movement.
        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;
    }

    // This is run repeatedly while the game is running 
    void Update()
    {
        // Controls the bat by moving left and right with the left and right keys.
        bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
        bool isRightPressed = Input.GetKey(KeyCode.RightArrow);

        // Direction the bat can go when left is pushed and only if it can go left.
        if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }
        // Direction the bat can go when right is pushed and only if it can go right.
        else if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }
        // Direction the bat can go if anything else is pushed.
        else
        {
            direction = 0.0f;
        }


    }

    // This method is run by Unity whenever the bat hits something.
    void OnCollisionEnter2D(Collision2D other)
    {
        // This switch statement compares the other game object name to each of the cases
        // within the switch. If the other game object name matches one of the cases then
        // all the statements underneath that case will be run, until the break statement.
        switch (other.gameObject.name)
        {
            // Prevents bat from moving past left wall.
            case "Left Wall":
                canMoveLeft = false;
                break;

            // Prevents bat from moving past right wall.
            case "Right Wall":
                canMoveRight = false;
                break;
        }
    }

    // This method is run by Unity after the bat hits something.
    void OnCollisionExit2D(Collision2D other)
    {
        // This switch statement compares the other game object name to each of the cases
        // within the switch. If the other game object name matches one of the cases then
        // all the statements underneath that case will be run, until the break statement.
        switch (other.gameObject.name)
        {
            // Allows the bat to move left after touching the wall.
            case "Left Wall":
                canMoveLeft = true;
                break;

            // Allows the bat to move right after touching the wall.
            case "Right Wall":
                canMoveRight = true;
                break;
        }
    }
}
