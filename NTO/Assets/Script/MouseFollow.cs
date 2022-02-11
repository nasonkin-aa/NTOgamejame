using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] Camera main;
    [SerializeField] Transform button;

    Vector3 min;
    Vector3 max;
    public bool _isWindowActive = false;


    void Start()
    {
        min = main.ViewportToWorldPoint(new Vector2(0, 0));
        max = main.ViewportToWorldPoint(new Vector2(1, 1));
        transform.position = new Vector3(
            main.transform.position.x,
            main.transform.position.y,
            0);
    }


    void FixedUpdate()
    {
        if (!_isWindowActive)
            return;

        transform.position = main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = new Vector3(Mathf.Round(transform.position.x) - 0.5f, Mathf.Round(transform.position.y) - 0.5f, transform.position.z);
        button.position = transform.position;

        var cubeSize = transform.GetComponent<Collider2D>().bounds.size;

        // ToDo: Возможно точки стоит обновлять не здесь
        min = main.ViewportToWorldPoint(new Vector2(0, 0));
        max = main.ViewportToWorldPoint(new Vector2(1, 1));


        // ToDo: Возможно оптимизировать или вынести
        if (transform.position.x + cubeSize.x / 2 + 0.5f > max.x)
        {
            transform.position = new Vector3(Mathf.Round(max.x - cubeSize.x / 2) - 0.5f, transform.position.y, transform.position.z);
            button.position = transform.position;
        }

        if (transform.position.x - cubeSize.x / 2 - 0.5f < min.x)
        {
            transform.position = new Vector3(Mathf.Round(min.x + cubeSize.x / 2) + 0.5f, transform.position.y, transform.position.z);
            button.position = transform.position;
        }

        if (transform.position.y + cubeSize.y / 2 + 0.5f > max.y)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Round(max.y - cubeSize.y / 2) - 0.5f, transform.position.z);
            button.position = transform.position;
        }

        if (transform.position.y - cubeSize.y / 2 - 0.5f < min.y)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Round(min.y + cubeSize.y / 2) + 0.5f, transform.position.z);
            button.position = transform.position;
        }

    }

    public void OnMouseDown()
    {
        _isWindowActive = true;
    }

    public void OnMouseUp()
    {
        _isWindowActive = false;
    }



}
