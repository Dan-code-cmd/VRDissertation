using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> spawnables = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < spawnables.Count; ++i) 
        {
            spawnables[i].SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
