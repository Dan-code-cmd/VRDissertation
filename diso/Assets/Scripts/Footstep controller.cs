using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Footstepcontroller : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public Transform m_Transform;
    private Vector3 initialPosition;
    private Vector3 previousPosition;
 
    bool audio = false;
    void Start()
    {
        initialPosition = transform.position;
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Compare positions using an if statement
        if (currentPosition != previousPosition)
        { 
            if (audio) 
            {
                
            }
            else
            {
                m_AudioSource.Play();
                audio = true;
            }
            Debug.Log("moving");
            audio = true;
            previousPosition = currentPosition;

        }
        else if (currentPosition == previousPosition)
        {
            audio = false;
            Debug.Log("stopped");
            m_AudioSource.Stop();
            previousPosition = currentPosition;
        }

    }
}
