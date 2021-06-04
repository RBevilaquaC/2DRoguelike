using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    
    public GameObject player;
    public Text healthText;
    public Text manaText;
    public Text coinText;
    public Slider healthSlider;

    public int coins;
    public int gems;
    public float health;
    public float maxHealth;

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
        UpdateHealthBar();
        UpdateCoinText();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        UpdateHealthBar();
    }

    public void HealCharacter(float heal)
    {
        health += maxHealth;
        CheckOverheal();
        UpdateHealthBar();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthBar();
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(player);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + "/" + Mathf.Ceil(maxHealth).ToString();
    }

    public void UpdateCoinText()
    {
        coinText.text = coins.ToString();
    }
}
