using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushParticleManager : MonoBehaviour
{

    public GameObject particleObject;
    public GameObject rainbowBurstParticle;
    public Transform particleSpawnPosForBrush;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Environnment")
        {
            GameObject newParticle = Instantiate(rainbowBurstParticle, particleSpawnPosForBrush.position, Quaternion.identity);
            Destroy(newParticle, 1);
            particleObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Environnment")
        {
            particleObject.SetActive(false);
        }
    }
}
