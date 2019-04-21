//Jake Poshepny

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Spawns List")]
    public List<EnemySpawner> spawners = new List<EnemySpawner>();

    //time between spawns
    public float spawnDelay = 1;

    private void Start()
    {
        //immediately call coroutine when the game is started
        StartCoroutine(SpawnDelay());
    }

    //coroutine that shuffles a list and calls a function after a specified time between each item in the list
    private IEnumerator SpawnDelay()
    {
        //shuffle the spawn order
        var shuffledSpawns = spawners.OrderBy(a => Guid.NewGuid()).ToList();

        for (int i = 0; i < shuffledSpawns.Count; i++)
        {
            //wait to spawn
            yield return new WaitForSeconds(spawnDelay);

            //spawn enemy
            shuffledSpawns[i].Spawn();

            //if the end of the list is reached, restart the coroutine
            if (i == shuffledSpawns.Count - 1)
            {
                StartCoroutine(SpawnDelay());
            }
        }
    }
}
