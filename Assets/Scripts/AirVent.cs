using System.Collections;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    public float gustForce = 10f; // The upward force applied to the player
    public float gustIntervalSeconds = 2f; // How often the gusts occur

    private bool playerIsOverVent = false; // Flag to check if the player is over the vent

    private void Start()
    {
        StartCoroutine(GustWindRoutine());
    }

    private IEnumerator GustWindRoutine()
    {
        // Infinite loop to periodically activate the gust
        while (true)
        {
            yield return new WaitForSeconds(gustIntervalSeconds);

            if (playerIsOverVent)
            {
                // Apply the gust force if the player is over the vent
                ApplyGustForce();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsOverVent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsOverVent = false;
        }
    }

    private void ApplyGustForce()
    {
        // Assuming the player's tag is "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            // Apply an upward force
            playerRigidbody.AddForce(Vector2.up * gustForce, ForceMode2D.Impulse);
        }
    }
}

