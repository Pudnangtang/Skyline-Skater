using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the drone's movement
    public float directionChangeInterval = 1.0f; // How often the drone changes its direction

    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        // Move the drone
        transform.Translate(movementPerSecond * Time.deltaTime);
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            // Generate a random direction
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            // Calculate the movement per second in the new direction
            movementPerSecond = movementDirection * speed;

            // Wait for the direction change interval before changing direction again
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

