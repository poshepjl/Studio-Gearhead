using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public SphereCollider effuxA;
    public bool isActive;
    public float activeLength;

    void Start()
    {
        effuxA = GetComponent<SphereCollider>();
        if (effuxA.enabled == true)
            effuxA.enabled = false;
    }
    public void UseDestruction()
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
                    Destroy(other.gameObject);
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
