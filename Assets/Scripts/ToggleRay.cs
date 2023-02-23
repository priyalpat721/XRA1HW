using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// to be attached to the controller for which you want to toggle RayInteractor
/// switches between RayInteractor and DirectInteractor
/// </summary>
public class ToggleRay : MonoBehaviour
{
    // define a public InputActionReference for toggle button
    public InputActionReference toggleReference;

    // and a reference to the rayInteractor GameObject to be toggled
    public GameObject rayInteractor;
    // need a global variable for the XRDirectInteractor reference
    XRDirectInteractor interactor;
    void Awake()
    {
        toggleReference.action.started += Pressed;
        // add Pressed and Released events to action's .started and .canceled states
        toggleReference.action.canceled += Released;
        // get a reference to the XRDirectInteractor attached to current gameObject
        interactor = GetComponent<XRDirectInteractor>();
    }

    private void OnDestroy()
    {
        // remove event listeners when destroyed
        toggleReference.action.started -= Pressed;
        toggleReference.action.canceled -= Released;
    }

    void Pressed(InputAction.CallbackContext context)
    {
        // toggle the Ray 
        Toggle();
    }

    void Released(InputAction.CallbackContext context)
    {
        // toggle the Ray
        Toggle();
    }

    void Toggle()
    {
        // get a bool, isToggled, for the current state of the rayInteractor
        bool isToggled = rayInteractor.activeSelf;
        if (!isToggled)
        {
            // set enable of the directInteractor based on the bool value
            interactor.enabled = false;
            // setActive of the rayInteractor based on the bool value
            rayInteractor.SetActive(true);
        }
        else
        {
            interactor.enabled = true;
            rayInteractor.SetActive(false);
        }
    }
}
