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

    [Header("Tutorial Enemy List")]
    public GameObject e1 = null;
    public GameObject e2 = null;
    public GameObject e3 = null;

    private int e1Phase = 0;
    private int e2Phase = 0;
    private int e3Phase = 0;

    [Header("Tutorial Enemy Limit")]
    public int e1PhaseLimit = 15;
    public int e2PhaseLimit = 15;
    public int e3PhaseLimit = 15;

    private bool e1Round = false;
    private bool e2Round = false;
    private bool e3Round = false;

    [Header("Time Between Spawns")]
    public float spawnDelay = 2;

    [Header("Tutorial Mode")]
    public bool tutorial = false;

    [Header("Instructions")]
    public GameObject e1Inst = null;
    public GameObject e2Inst = null;
    public GameObject e3Inst = null;
    public GameObject finalInst = null;

    [Header("Ability References")]
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;

    private void Start()
    {
        TutorialToggle t = GameObject.FindGameObjectWithTag("CSM").GetComponent<TutorialToggle>();

        if (t.tutorial == true)
            tutorial = true;
        else if (t.tutorial == false)
            tutorial = false;

        switch (tutorial)
        {
            case true:
                Time.timeScale = 0;
                e1Inst.SetActive(true);
                e2Inst.SetActive(false);
                e3Inst.SetActive(false);
                a1.SetActive(true);
                a2.SetActive(false);
                a3.SetActive(false);
                break;

            case false:
                e1Inst.SetActive(false);
                e2Inst.SetActive(false);
                e3Inst.SetActive(false);
                a1.SetActive(true);
                a2.SetActive(true);
                a3.SetActive(true);

                //immediately call coroutine when the game is started
                StartCoroutine(SpawnDelay());
                break;
        }
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

    private IEnumerator TutorialSpawnDelay(GameObject enemyType)
    {
        //shuffle the spawn order
        var shuffledSpawns = spawners.OrderBy(a => Guid.NewGuid()).ToList();

        for (int i = 0; i < shuffledSpawns.Count; i++)
        {
            if (e1Round)
                e1Phase++;
            if (e2Round)
                e2Phase++;
            if (e3Round)
                e3Phase++;
            
            //wait to spawn
            yield return new WaitForSeconds(spawnDelay);

            //spawn enemy
            shuffledSpawns[i].TutorialSpawn(enemyType);

            //if the end of the list is reached, restart the coroutine
            if (i == shuffledSpawns.Count - 1)
            {
                if (e1Round)
                {
                    if (e1Phase == 15)
                    {
                        Time.timeScale = 0;
                        e2Inst.SetActive(true);
                        a2.SetActive(true);
                    }
                    else
                        StartCoroutine(TutorialSpawnDelay(e1));

                }
                if (e2Round)
                {
                    if (e2Phase == 15)
                    {
                        Time.timeScale = 0;
                        e3Inst.SetActive(true);
                        a3.SetActive(true);
                    }
                    else
                        StartCoroutine(TutorialSpawnDelay(e2));

                }
                if (e3Round)
                {
                    if (e3Phase == 15)
                    {
                        Time.timeScale = 0;
                        finalInst.SetActive(true);
                    }
                    else
                        StartCoroutine(TutorialSpawnDelay(e3));

                }
            }
        }
    }

    public void StartPhase1()
    {
        e1Round = true;
        e2Round = false;
        e3Round = false;
        StartCoroutine(TutorialSpawnDelay(e1));
        Time.timeScale = 1;
        e1Inst.SetActive(false);
    }

    public void StartPhase2()
    {
        e1Round = false;
        e2Round = true;
        e3Round = false;
        StartCoroutine(TutorialSpawnDelay(e2));
        Time.timeScale = 1;
        e2Inst.SetActive(false);
    }

    public void StartPhase3()
    {
        e1Round = false;
        e2Round = false;
        e3Round = true;
        StartCoroutine(TutorialSpawnDelay(e3));
        Time.timeScale = 1;
        e3Inst.SetActive(false);
    }

    public void StartNormalPhase()
    {
        e1Round = false;
        e2Round = false;
        e3Round = false;
        StartCoroutine(SpawnDelay());
        Time.timeScale = 1;
        finalInst.SetActive(false);
    }
}
