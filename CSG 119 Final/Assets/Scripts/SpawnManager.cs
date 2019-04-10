//Jake Poshepny

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpawnManager : MonoBehaviour
{
    [Header("Amount of Spawners and Time Delays need to be equal in order to work properly")]
    [Header("List of Enemy Spawners")]
    public List<EnemySpawner> spawners = new List<EnemySpawner>();

    [Header("List of Time Delays")]
    public List<int> delays = new List<int>();

    private void Start()
    {
        var shuffledDelays = delays.OrderBy(a => Guid.NewGuid()).ToList();
        
        for (int i = 0; i < shuffledDelays.Count; i++)
        {
            spawners[i].initialDelay = shuffledDelays[i];
        }
    }
}
