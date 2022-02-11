using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] Camera main;

    Vector3 min;
    Vector3 max;


    void Start()
    {
        min = main.ViewportToWorldPoint(new Vector2(0, 0));
        max = main.ViewportToWorldPoint(new Vector2(1, 1));
    }


    void FixedUpdate()
    {
        transform.position = main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);

        var cubeSize = transform.GetComponent<Collider2D>().bounds.size;

        // ToDo: Возможно точки стоит обновлять не здесь
        min = main.ViewportToWorldPoint(new Vector2(0, 0));
        max = main.ViewportToWorldPoint(new Vector2(1, 1));


        // ToDo: Возможно оптимизировать или вынести
        if (transform.position.x + cubeSize.x / 2 > max.x)
        {
            transform.position = new Vector3 (max.x - cubeSize.x / 2, transform.position.y, transform.position.z);
        }

        if ( transform.position.x - cubeSize.x / 2 < min.x)
        {
            transform.position = new Vector3(min.x + cubeSize.x / 2, transform.position.y, transform.position.z);
        }

        if (transform.position.y + cubeSize.y / 2 > max.y )
        {
            transform.position = new Vector3(transform.position.x, max.y - cubeSize.y / 2, transform.position.z);
        }

        if ( transform.position.y - cubeSize.y / 2 < min.y)
        {
            transform.position = new Vector3(transform.position.x, min.y + cubeSize.y / 2, transform.position.z);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject newCube = GameObject.Instantiate(collision.gameObject);
            newCube.transform.position = new Vector3(0, 0, 0);
        }
    }
}
