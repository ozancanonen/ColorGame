using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPaint : MonoBehaviour
{
    private bool destroy=true;
    private void Start()
    {
        StartCoroutine(DestroyIF());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Environnment")
        {
            destroy = false;
        }
    }
    IEnumerator DestroyIF()
    {
        yield return new WaitForSeconds(2f);
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
}
