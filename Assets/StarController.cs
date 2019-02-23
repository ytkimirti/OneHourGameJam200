using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarController : MonoBehaviour
{
    public Transform trans;
    public float rotateSpeed;

    void Start()
    {

    }

    void Update()
    {
        trans.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            GameManager.main.InreaseStar();

            GetComponent<Collider2D>().enabled = false;

            transform.DOScale(Vector2.zero, 0.2f).OnComplete(die).SetEase(Ease.OutElastic);
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
