using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaterialChanger : MonoBehaviour
{
    public GameObject wand;
    public ParticleSystem particles;

    Color wandColor;
    MeshRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "WandTip")
        {
            GameObject wandTip = wand.transform.GetChild(0).gameObject;
            AudioSource soundEffect = wandTip.GetComponent<AudioSource>();
            Destroy(Instantiate(particles, wandTip.transform.position, wandTip.transform.rotation), 0.5f);
            soundEffect.Play();
            wandColor = wandTip.GetComponent<MeshRenderer>().material.color;
            _renderer.material.color = wandColor;
        }
    }
}
