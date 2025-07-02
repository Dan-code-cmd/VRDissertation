using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public StatController statController;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Trigger Enter: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet hit!");
            Destroy(this.gameObject);
            statController.shotsHit++;
        }

    }
}
