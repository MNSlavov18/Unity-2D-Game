using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealt;

    [SerializeField]
    private GameObject
        deatchChunk,
        deadBlod;

    private float currentHealth;

    private GameManager Gm;

    private void Start()
    {
        currentHealth = maxHealt;
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deatchChunk, transform.position, deatchChunk.transform.rotation);
        Instantiate(deadBlod, transform.position, deadBlod.transform.rotation);
        Gm.Respawn();
        Destroy(gameObject);
    }

}

