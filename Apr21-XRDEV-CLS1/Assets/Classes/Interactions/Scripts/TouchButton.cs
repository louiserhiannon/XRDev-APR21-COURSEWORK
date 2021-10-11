using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform depressed;
    public Transform button;
    
    public AudioSource audioSource;

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = button.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = depressed.position;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.position = originalPosition;
        }
    }
}
