using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Player Components")]
    public Slider valueMove;

    public void ConvertMove() { transform.localEulerAngles = new Vector3(0, valueMove.value, 0); Debug.Log("Pro Strats"); }
}
