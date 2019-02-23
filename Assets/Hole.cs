using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Hole : MonoBehaviour
{

    public Color deactivatedColor;
    public Color activatedColor;

    public bool isActivated;
    public SpriteRenderer sprite;

    void Start()
    {

    }

    void Update()
    {
        if (isActivated)
        {
            sprite.color = activatedColor;
        }
        else
        {
            sprite.color = deactivatedColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CameraShaker.Instance.ShakeOnce(1, 7, 0, 0.4f);

        if (other.gameObject.tag == "Circle")
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            isActivated = false;
        }
    }
}
