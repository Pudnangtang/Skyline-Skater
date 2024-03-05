using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conflict : MonoBehaviour
{
    public float speed = 5f; // Speed of pacing
    public float moveDistance = 5f; // Distance to move in each direction from the starting point

    private float leftBoundary;
    private float rightBoundary;
    private int direction = 1; // 1 for right, -1 for left
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        leftBoundary = startPosition.x - moveDistance;
        rightBoundary = startPosition.x + moveDistance;
    }

    private void Update()
    {
        // Move the GameObject
        Move();
    }

    private void Move()
    {
        // Move GameObject left or right
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Check if the GameObject has reached its boundaries
        if (transform.position.x >= rightBoundary)
        {
            direction = -1; // Move left
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1; // Move right
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
