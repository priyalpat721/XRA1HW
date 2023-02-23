using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteObject : MonoBehaviour
{
    public InputActionReference _inputReference;
    public AudioClip audioClip;
    public ParticleSystem particles;

    public void Awake()
    {
        _inputReference.action.started += DestroyObject;
    }

    private void DestroyObject(InputAction.CallbackContext context)
    {

        if (gameObject.GetComponent<XRGrabInteractable>().isSelected)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            Destroy(Instantiate(particles.gameObject, gameObject.transform.position, gameObject.transform.rotation), 0.21f);
            Destroy(gameObject, 0.15f);
            _inputReference.action.started -= DestroyObject;
        }

    }
}
