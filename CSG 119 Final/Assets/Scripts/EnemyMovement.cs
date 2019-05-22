using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public Vector3 playerPosition;

    private bool canMove = false;

    private GameObject player;

    public bool halfDamage;

    public EnemyDeathAnimation EDA;

    private void Awake()
    {
        speed = GetComponent<EnemyStats>().speed;

        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.GetComponent<Transform>().position;

        transform.LookAt(playerPosition);

        StartCoroutine(MoveDelay());
    }

    private void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<AudioSource>().PlayOneShot(other.GetComponent<AudioSource>().clip);

            if (halfDamage == true)
                player.GetComponent<PlayerStats>().currentHealth -= 0;
            else
                player.GetComponent<PlayerStats>().currentHealth -= GetComponent<EnemyStats>().damage;
            player.GetComponent<PlayerStats>().UpdateHealthSlider();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Shield")
        {
            player.GetComponent<PlayerStats>().score += GetComponent<EnemyStats>().scoreValue;
            player.GetComponent<PlayerStats>().UpdateScore();
        }
    }

    public void DestroyEnemy()
    {
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
