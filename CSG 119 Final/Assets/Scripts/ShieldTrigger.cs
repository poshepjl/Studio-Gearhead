using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldTrigger : MonoBehaviour
{
    public CapsuleCollider theShield;
    public SpriteRenderer shieldImage;
    public Sprite[] differentShields;
    public Image shieldColor;
    public GameObject partPass;
    public enum ShieldState
    {
        Blue,
        Yellow,
        Green
    }
    public ShieldState shieldState;
    public ShieldState enemyState;

    void Start()
    {
        theShield = GetComponent<CapsuleCollider>();
    }
    public void ShieldSwitch()
    {
        if (shieldState == ShieldState.Blue)
        {
            shieldState = ShieldState.Green;
            shieldImage.sprite = differentShields[1];
            shieldColor.color = new Color32(0, 255, 0, 255);
            return;
        }
        if (shieldState == ShieldState.Green)
        {
            shieldState = ShieldState.Yellow;
            shieldImage.sprite = differentShields[2];
            shieldColor.color = new Color32(255, 255, 0, 255);
            return;
        }
        if (shieldState == ShieldState.Yellow)
        {
            shieldState = ShieldState.Blue;
            shieldImage.sprite = differentShields[0];
            shieldColor.color = new Color32(0, 0, 255, 255);
            return;
        }
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name != "Player")
        {
            if (shieldState != enemyState)
            {
                partPass.SetActive(true);
                StartCoroutine(DisablePart());
            }

            if (other.tag == "Blue")
            {
                enemyState = ShieldState.Blue;
                if (shieldState == enemyState)
                {
                    other.gameObject.GetComponent<EnemyMovement>().EDA.PlayDeathAnim();
                    other.gameObject.GetComponent<EnemyMovement>().speed = 0;

                    yield return new WaitForSeconds(1);

                    Destroy(other.gameObject);
                    Debug.Log("Wipe");
                }
            }
            if (other.tag == "Yellow")
            {
                enemyState = ShieldState.Yellow;
                if (shieldState == enemyState)
                {
                    //other.gameObject.GetComponent<EnemyMovement>().EDA.PlayDeathAnim();
                    //other.gameObject.GetComponent<EnemyMovement>().speed = 0;

                    //yield return new WaitForSeconds(1);

                    Destroy(other.gameObject);
                    Debug.Log("wipeY");
                }
            }

            if (other.tag == "Green")
            {
                enemyState = ShieldState.Green;
                if (shieldState == enemyState)
                {
                    other.gameObject.GetComponent<EnemyMovement>().EDA.PlayDeathAnim();
                    other.gameObject.GetComponent<EnemyMovement>().speed = 0;

                    yield return new WaitForSeconds(1);

                    Destroy(other.gameObject);
                    Debug.Log("Wipeg");
                }
            }


       //     Debug.Log("Shield // " + Time.time);
        }
    }

    IEnumerator DisablePart()
    {
        yield return new WaitForSeconds(0.1f);
        partPass.SetActive(false);
    }
}
