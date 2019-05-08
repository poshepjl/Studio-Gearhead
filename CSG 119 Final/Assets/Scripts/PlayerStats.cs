using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector] public float currentHealth;

    public Slider healthSlider;

    public float score;

    public Text scoreText;

    public List<Sprite> sprites = new List<Sprite>();

    public SpriteRenderer sr;

    private Manager manager;

    private void Start()
    {
        currentHealth = maxHealth;

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void Update()
    {
        scoreText.text = score.ToString();

        HealthSprites();
    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void HealthSprites()
    {
        if (currentHealth >= 76)
        {
            sr.sprite = sprites[0];
        }

        if (currentHealth >= 51 && currentHealth <= 75)
        {
            sr.sprite = sprites[1];
        }

        if (currentHealth >= 26 && currentHealth <= 50)
        {
            sr.sprite = sprites[2];
        }

        if (currentHealth >= 1 && currentHealth <= 25)
        {
            sr.sprite = sprites[3];
        }

        if (currentHealth <= 0)
        {
            sr.sprite = sprites[4];

        }
    }
}
