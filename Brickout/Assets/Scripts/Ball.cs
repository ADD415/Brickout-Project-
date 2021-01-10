using UnityEngine;

class Ball : MonoBehaviour
{
    // This variable should be set in the Inspector to a game object which
    // contains a BallSpawner component.
    public BallSpawner spawner = null;

    public Bat Bat = null; // This variable should be set in the Inspector to a game object which contains a Bat component.
    public float size = 1.0f; // Ball size, allows later code using size to be used. Float allows for decimal numbers.
    float speed = 0.2f; // Ball speed, allows later code using speed to be used.
    int lives = 1; // How many lives you have, allows later code using lives to be used.
    float directionX = 1.0f; // Direction for x axis, allows later code using direction for x axis to be used.
    float directionY = 0.5f; // Direction for y axis, allows later code using direction for y axis to be used.
    public AudioSource BounceSound; // Bounce sound to be used later

    // Set the direction of the ball, in degrees.
    public void SetDirection(int angleInDegrees)
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        directionX = Mathf.Cos(angleInRadians);
        directionY = Mathf.Sin(angleInRadians);
    }

    // This method is usually run by Unity when the object is created (when the game
    // is first run), but also whenever the object is activated after being inactive.
    void Start()
    {
        // Speed of ball upon starting.
        speed = 0.2f / size;

        // Reduces live count.
        float fractionalScore = 1 / size;
        lives = (int)fractionalScore;

        // Prints the current value in the console menu.
        string message = name + " size is " + size + ", speed is " + speed + ", lives is " + lives;
        print(message);
    }

    // Used for ball movement, FixedUpdate insures ideal movement.
    void FixedUpdate()
    {
        // Ball movement.
        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        position.y += speed * directionY;
        transform.localPosition = position;
    }

    // This method is run by Unity whenever the ball hits something. The 'other' parameter
    // contains details about the collision, including the other game object that was hit.
    void OnCollisionEnter2D(Collision2D other)
    {
        // This switch statement compares the other game object name to each of the cases
        // within the switch. If the other game object name matches one of the cases then
        // all the statements underneath that case will be run, until the break statement.
        switch (other.gameObject.name)
        {
            case "Left Wall":
            case "Right Wall":
                directionX = -directionX; // Invert the direction horizontally.
                BounceSound.Play(); // Plays bounce sound 
                break;

            case "Top Wall":
            case "Bat":
                directionY = -directionY; // Invert the direction vertically.
                BounceSound.Play(); // Plays bounce sound 
                break;

            case "Brick":
            case "Row 2":
            case "Row 3":
            case "Row 4":
            case "Brick (1)":
            case "Brick (2)":
            case "Brick (3)":
            case "Brick (4)":
                directionY = -directionY; // Invert the direction vertically.
                break;

            case "Goal":
                Bat.Decreaselives(lives); // Decrease Player live count.
                spawner.DespawnBall(this);     // Despawn this ball.
                break;

            default:
                // If the ball has hit something not listed above, log a console message.
                print(name + " has collided with " + other.gameObject.name);
                break;
        }
    }
}


