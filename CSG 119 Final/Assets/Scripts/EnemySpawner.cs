//Jake Poshepny

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    public float delay;

    public float initialDelay;

    private bool waiting = true;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(initialDelay);
        waiting = false;
    }

    private void Update()
    {
        if (waiting == false)
        {
            StartCoroutine(SpawnDelay());
        }
    }

    private IEnumerator SpawnDelay()
    {
        waiting = true;
        Spawn();
        yield return new WaitForSeconds(delay);
        waiting = false;
    }

    private void Spawn()
    {
        Debug.Log("SPAWN");
    }
}
