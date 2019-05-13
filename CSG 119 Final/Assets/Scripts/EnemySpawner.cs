//Jake Poshepny

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("List of Enemies")]
    public List<GameObject> enemies = new List<GameObject>();

    //spawns the enemies
    public void Spawn()
    {
        //pick a random enemy
        int n = Random.Range(0, enemies.Count);

        //instantiate the picked enemy
        GameObject e = Instantiate(enemies[n], transform.position, Quaternion.identity);
    }

    public void TutorialSpawn(GameObject enemyType)
    {
        GameObject e = Instantiate(enemyType, transform.position, Quaternion.identity);
    }
}
