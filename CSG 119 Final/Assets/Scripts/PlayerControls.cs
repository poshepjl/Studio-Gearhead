﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 1;
    public int playerScore;

    [Header("Player Abilitys")]
    public GameObject[] abilitys; //1 - Shield //2 - //3 - //4- //5-

    [Header("Player Components")]
    public Slider valueMove;
    public Slider sliderHealth;
    public Text scoreText;

    void Start()
    {
        health = maxHealth;
        abilitys[0] = transform.GetChild(0).gameObject;
        abilitys[1] = transform.GetChild(0).gameObject;
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

    public void UseAbility1()
    {
        abilitys[1].SetActive(true);
        abilitys[1].SetActive(false);

    }
    public void UseAbility2()
    {

    }
    public void UseAbility3()
    {

    }
    public void UseAbility4()
    {

    }
}