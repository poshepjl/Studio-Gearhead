using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    public CapsuleCollider theShield;

    void Start()
    {
        theShield = GetComponent<CapsuleCollider>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name != "Player")
        {
            Destroy(other.gameObject);
            Debug.Log("Shield // " + Time.time);
        }
    }
}
