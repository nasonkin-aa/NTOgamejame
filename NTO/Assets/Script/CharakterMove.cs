using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterMove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var moveVector = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector * speed, rb.velocity.y);
    }
}
