using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazineController : XRBaseInteractable
{

    int magazineSize = 6;
    public GameObject magazinePrefab;

    Collider instansiateArea;
    public InputActionReference ButtonPressed;
    public ActionBasedController leftController;

    public GameObject spawnLocation;

    public XRRayInteractor interactor;

    public GameObject newobj;

    // Start is called before the first frame update
    void Start()
    {
        instansiateArea = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        ButtonPressed.action.performed += InstantiateMag;
    }

    public void InstantiateMag(InputAction.CallbackContext context)
    {
        Debug.Log("running function");

        Vector3 controllerPosition = leftController.transform.position;

        //Vector3 spawnOffset = leftController.transform.forward * 0.01f;

        if (GetComponent<Collider>().bounds.Contains(controllerPosition))
        {

            newobj = Instantiate(magazinePrefab, spawnLocation.transform.position, Quaternion.identity);

            XRBaseInteractable interactable = newobj.GetComponent<XRGrabInteractable>();


        }



    }


}