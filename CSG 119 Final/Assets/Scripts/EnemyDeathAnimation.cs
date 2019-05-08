using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAnimation : MonoBehaviour
{
    public bool dead = false;

    public Animator anim;

    private IEnumerator Start()
    {
        anim = GetComponent<Animator>();

        yield return new WaitForSeconds(0);

        anim.SetBool("dead", dead);
    }

    public void PlayDeathAnim()
    {
        dead = true;
        anim.SetBool("dead", dead);
    }
}
