using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public Vector3 playerPosition;

    private bool canMove = false;

    private void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        transform.LookAt(playerPosition);

        StartCoroutine(MoveDelay());
    }

    private void Update()
    {
        if (canMove)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
            Destroy(gameObject);
        }
    }
}
