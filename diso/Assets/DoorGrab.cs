using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrab : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform handler;
    public bool isGrabbed;
    public XRBaseInteractor interactor;

    void Start()
    {
        isGrabbed = false;  
    }

    public void UpdatePos()
    {
        transform.localScale = Vector3.one;

        transform.position = handler.position;
        transform.rotation = handler.rotation;

        Rigidbody rigidbody = handler.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        isGrabbed = false;
        interactor.allowSelect = true; 
    }
    public void grab() 
    {
        isGrabbed = true;
    }
    private void Update()
    {
        if (isGrabbed) 
        {
            checkDistance();
        }
    }

    public void checkDistance() 
    {
        if(Vector3.Distance(handler.position,transform.position) > 0.4f) 
        {
            interactor.allowSelect = false;
            Debug.Log("Distance exceeded 0.4!");
        }
    }
    // Update is called once per frame

}
