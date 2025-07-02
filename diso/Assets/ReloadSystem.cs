using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSystem : MonoBehaviour
{
    public int magSize = 6;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magazine"))
        {
            Destroy(other.gameObject);
            magSize = 6;
        }
    }

    public void Reload()
    {
        magSize = 6;
        Debug.Log("reloading");
    }
    public void Empty()
    {
        Debug.Log("emptying");
        magSize = 0;
    }

}

