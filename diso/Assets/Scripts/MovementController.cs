using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            if (this.GetComponent<ActionBasedSnapTurnProvider>().enabled == true)
            {
                Debug.Log("turning to snap turn");
                this.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
                this.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;

            }
            else if (this.GetComponent<ActionBasedContinuousTurnProvider>().enabled == true) 
            {
                Debug.Log("turning to snap turn");
                this.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
                this.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("pressing S");
            if (this.GetComponent<TeleportationProvider>().enabled == true) 
            {
                this.GetComponent<TeleportationProvider>().enabled = false;
                this.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
            }
            if (this.GetComponent<ActionBasedContinuousMoveProvider>().enabled == true)
            {
                this.GetComponent<TeleportationProvider>().enabled = true;
                this.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed -= 1;
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            this.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed += 10;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed -= 10;
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            this.GetComponent<XROrigin>().CameraYOffset += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            this.GetComponent<XROrigin>().CameraYOffset -= 0.1f;
        }
    }
}
