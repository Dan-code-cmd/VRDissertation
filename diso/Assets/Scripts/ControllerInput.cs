using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerInput : MonoBehaviour
{
    public InputActionReference triggerAmount;
    public ActionBasedController rightController;
    public ActionBasedController leftController;


    // Start is called before the first frame update
    void Start()
    {
        triggerAmount.action.performed += TriggerPressed;
        triggerAmount.action.canceled += TriggerPressed;
    }

    void TriggerPressed(InputAction.CallbackContext context)
    {
        float triggerAmount = context.ReadValue<float>();
        //Debug.Log("right trigger value = " + triggerAmount);
        if (triggerAmount > 0.5f) 
        {
            leftController.SendHapticImpulse(0.5f, 0.1f);
            rightController.SendHapticImpulse(0.5f, 0.1f);
        }
    }
}
