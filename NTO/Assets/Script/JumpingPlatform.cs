using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private float _timeForeNextJump = 2f;
    [SerializeField] private LayerMask _layerMask;
    private float _jumpDelay = 0;
    private string _playerTag = "Player";
    private RaycastHit2D _hit;


    private void Awake()
    {
        if (_player == null)
            _player = GameObject.FindGameObjectWithTag(_playerTag).transform;

    }

    private void FixedUpdate()
    {
        if (_jumpDelay > 0)
        {
            _jumpDelay -= Time.deltaTime;
            return;
        }

        RayCast();
    }

    private void RayCast()
    {
        _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, _layerMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 1f, Color.red);

        if (_hit.transform == _player && _jumpDelay <= 0)
        {
            _player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
            _jumpDelay = _timeForeNextJump;
        }

    }
}
