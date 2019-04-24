using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetModification : MonoBehaviour
{
    public BoxCollider effuxA;
    public bool isActive;
    public float activeLength;

    void Start()
    {
        effuxA = GetComponent<BoxCollider>();
        if (effuxA.enabled == true)
            effuxA.enabled = false;
    }
    public void UseTargetModification()
    {
        if (isActive == false)
        {
            effuxA.enabled = true;
            isActive = true;
            StartCoroutine(ActiveLength());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (isActive == true)
        {
            if (other.transform.root.name != "Player")
            {
                    other.GetComponent<EnemyMovement>().halfDamage = true;
                    Debug.Log("Yolo");
            }
        }
    }
    IEnumerator ActiveLength()
    {
        yield return new WaitForSeconds(activeLength);
        isActive = false;
        effuxA.enabled = false;
    }
}
