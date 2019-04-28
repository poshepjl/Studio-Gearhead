using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneModification : MonoBehaviour
{
    public SphereCollider parentPass;
    public bool isActive;
    public float activeLength;

    void Start()
    {
        parentPass = GetComponentInParent<SphereCollider>();
    }
    public void UseGeneModification()
    {
        if (isActive == false)
        {
            parentPass.enabled = false;
            isActive = true;
            StartCoroutine(ActiveLength());
        }
    }
    IEnumerator ActiveLength()
    {
        yield return new WaitForSeconds(activeLength);
        isActive = false;
        parentPass.enabled = true;
    }
}
