using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public Image switchImage;
    public Sprite[] tutorialSprites;
    [SerializeField]private int current = 0;

    public void NextImage(Object yolo)
    {
        if (current < 5)
            current++;
        else
            SceneManager.LoadScene(yolo.name);


        switchImage.sprite = tutorialSprites[current];




    }
    public void PreviousImage()
    {
        if (current > 0)
            current--;

        switchImage.sprite = tutorialSprites[current];
    }
}
