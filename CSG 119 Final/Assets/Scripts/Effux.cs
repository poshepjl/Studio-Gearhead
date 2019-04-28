using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effux : MonoBehaviour
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
    public void UseEffux()
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
                if (other.GetComponent<EnemyMovement>() != null)
                {
                    EnemyMovement em = other.GetComponent<EnemyMovement>();
                    em.speed = -em.speed;
                    Debug.Log("Efflux // " + Time.time);
                    //Bool Function True
                }
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
