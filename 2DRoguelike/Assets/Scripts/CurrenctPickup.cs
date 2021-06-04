using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrenctPickup : MonoBehaviour
{
    public int pickupQuantity;
    public enum pickupObject {COIN, GEM};
    public pickupObject currentObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        if (other.tag == "Player")
        {
            if (currentObject == pickupObject.COIN)
            {
                PlayerStats.playerStats.coins += pickupQuantity;
                PlayerStats.playerStats.UpdateCoinText();
            } else if (currentObject == pickupObject.GEM)
            {
                PlayerStats.playerStats.gems += pickupQuantity;
            }
            Destroy(gameObject);
        }
    }
}
