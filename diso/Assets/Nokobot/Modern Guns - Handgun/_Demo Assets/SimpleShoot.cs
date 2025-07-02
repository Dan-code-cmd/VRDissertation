using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public ActionBasedController rightController;
    public InputActionReference ButtonPressed;
    public StatController statController;
    public bool shot;
    float firerate = 1.0f;
    bool delay_ = false;
    public AudioSource gunshot;
    public ReloadSystem reloadSystem;
    public Collider magCollider { get; private set; }
    public Collider gunCollider;
    public GameObject magPrefab;

    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    void Start()
    {
        shot = false;


        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        
        
        ButtonPressed.action.performed += Shoot;






    }
    void Update()
    {
        //If you want a different input, change it here
        //Calls animation on the gun that has the relevant animation events that will fire

    }

    private IEnumerator FireDelay(float fireRate) 
    {
        //Debug.Log("delaying");
        delay_ = true;
        yield return new WaitForSeconds(fireRate);
        shot = false;
        
        
    }
    //This function creates the bullet behavior
    public void incrementShot()
    {
        statController.shotsFired++;
    }
    public void Reload()
    {
        
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (reloadSystem.magSize != 0)
        {
            if (shot == false)
            {
                reloadSystem.magSize--;
                incrementShot();
                delay_ = false;
                shot = true;
                gunshot.time = 0.4f;

                if (muzzleFlashPrefab)
                {
                    gunAnimator.SetTrigger("Fire");

                    GameObject tempFlash;
                    tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

                    Destroy(tempFlash, destroyTimer);
                    gunshot.Play();

                }
                //cancels if there's no bullet prefeb
                if (!bulletPrefab)
                { return; }
                // Create a bullet and add force on it in direction of the barrel
                Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            }
            else if (!delay_)
            {
                StartCoroutine(FireDelay(firerate));
            }
        }
        else 
        {
        } 
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
