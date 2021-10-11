using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedButton : MonoBehaviour
{
    public AudioSource audioSource;
    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;

    private Animator buttonAnim;
    public Color unPressedColour;
    public Color pressedColour;

    private Material buttonMaterial;
    

    void Awake()
    {
        buttonAnim = GetComponent<Animator>();
        buttonMaterial = GetComponentInChildren<Renderer>().material;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Pressed");
            audioSource.Play();
            OnButtonPressed();
            buttonMaterial.color = pressedColour;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Released");
            buttonMaterial.color = unPressedColour;
        }
    }

}
