using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // ToDo: Добавить проверку на наличие трансформа игрока
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraSpeed = 5f;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        Vector3 target = new Vector3()
        {
            x = playerTransform.position.x,
            y = playerTransform.position.y,
            z = transform.position.z,
        };

        Vector3 pos = Vector3.Lerp(transform.position, target, cameraSpeed);

        transform.position = pos;
    }
}
