﻿using System.Collections;
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

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
