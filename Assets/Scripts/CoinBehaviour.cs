using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for working with UI
using TMPro;

public class CoinBehaviour : MonoBehaviour
{
    public AudioClip CollectSound;
    public static int coinCount = 0; // Static variable to keep track of coins collected across all instances
    public TMP_Text coinCountText; // Assign this in the inspector

    private void Start()
    {
        // Update UI Text on start to show initial coin count
        UpdateCoinCountUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(CollectSound, Vector3.zero);

        // Increment coin count and update UI
        coinCount++;
        UpdateCoinCountUI();

        Destroy(gameObject);
    }

    private void UpdateCoinCountUI()
    {
        if (coinCountText != null)
            coinCountText.text = "Spray Cans: " + coinCount;
        else
            Debug.LogWarning("CoinCountText not set on " + gameObject.name);
    }
}
