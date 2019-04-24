using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 1;
    public int playerScore;

    [Header("Player Components")]
    public Slider valueMove;
    public Slider sliderHealth;
    public Text scoreText;

    void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        sliderHealth.value = health;
        scoreText.text = "Score: " + playerScore;
    }
    public void ConvertMove()
    {
        transform.localEulerAngles = new Vector3(0, valueMove.value, 0);
    }
}
