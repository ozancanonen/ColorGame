using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public float alphaChangeSpeed;
    public SpriteRenderer sr;
    private Color newColor;
    private Vector3 tempScaleValues;
    public GameObject fullyPaintedParticles;
    public GameObject paintBar;
    public GameObject paintBarParent;



    // Start is called before the first frame update


    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.tag == "Brush" && sr.color.a > 0)
        {
            paintBarParent.SetActive(true);
            newColor = sr.color;
            tempScaleValues = paintBar.transform.localScale;
            tempScaleValues.x = 1 - newColor.a;
            paintBar.transform.localScale = tempScaleValues;
            newColor.a = newColor.a - alphaChangeSpeed/1000;
            sr.color = newColor;
            if (sr.color.a <= 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("FullyColored");
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                fullyPaintedParticles.SetActive(true);
                Destroy(paintBarParent);
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(20);
        }
    }
}

