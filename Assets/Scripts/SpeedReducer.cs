using UnityEngine;

public class SpeedReducer : MonoBehaviour
{
    public float slowFactor = 0.5f; // The factor by which the player's speed is reduced
    private float originalSpeed = 0f; // To store the player's original speed
    private bool playerSlowed = false; // To check if the player is already slowed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerSlowed)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Store the original speed
                originalSpeed = playerMovement.moveSpeed;
                // Reduce the player's speed
                playerMovement.moveSpeed *= slowFactor;
                playerSlowed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerSlowed)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Restore the player's speed to its original value
                playerMovement.moveSpeed = originalSpeed;
                playerSlowed = false;
            }
        }
    }
}
