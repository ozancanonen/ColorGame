using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{

    public GameObject enemyDeadParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.tag == "Brush")
            {
                gameObject.GetComponent<Animator>().SetTrigger("FullyColored");
                GameObject newParticle = Instantiate(enemyDeadParticles, transform.position, Quaternion.identity);
                Destroy(newParticle, 1);
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

            }
    }

}
