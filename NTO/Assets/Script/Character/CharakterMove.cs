using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterMove : MonoBehaviour
{
    [SerializeField] float normalSpeed = 2f;
    private float speed = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0f;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void OnLeftButtonDown()
    {
        transform.rotation = new Quaternion(0,180f,0,0);
        if (speed >= 0f)
            speed -= normalSpeed;
    }

    public void OnRightButtonDown()
    {
        transform.rotation = new Quaternion(0, 0, 0, 1);
        if (speed <= 0f)
            speed += normalSpeed;
    }

    public void OnButtonUp()
    {
        speed = 0f;
    }
}
