using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpawner : MonoBehaviour
{

    public GameObject paintObject;
    public GameObject prefabsParentObject;
    private GameObject prefabObject;
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("SpawnObject", 0, 0.01f);
    }
    void Update()
    {

    }

    void SpawnObject()
    {
        prefabObject= Instantiate(paintObject, transform.position, Quaternion.identity);
        prefabObject.transform.parent = prefabsParentObject.transform;


    }
}
