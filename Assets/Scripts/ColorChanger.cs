using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public InputActionReference _inputReference;
    public AudioClip audioClip;

    MeshRenderer _renderer;

    private Color[] colorList = new Color[] { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.gray, Color.white };

    void Awake()
    {
        _inputReference.action.started += ColorChange;
    }

    private void Start()
    {
        _renderer = gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
    }


    private void ColorChange(InputAction.CallbackContext context)
    {
        if (gameObject.GetComponent<XRGrabInteractable>().isSelected)
        {
            int newColor = new System.Random().Next(0, colorList.Length);
            Color newColorChange = colorList[newColor];
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);

            _renderer.material.color = newColorChange;
        }

    }
}
