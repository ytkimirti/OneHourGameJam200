using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{

    public bool isRight;

    public float speed;
    public float maxSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (isRight)
        {
            input.x = -input.x;
        }

        rb.AddForce(speed * input.normalized, ForceMode2D.Impulse);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CameraShaker.Instance.ShakeOnce(1, 7, 0, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);

            GameManager.main.GameOver();
        }
    }
}
