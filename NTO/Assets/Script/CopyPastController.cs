using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPastController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject newCube = GameObject.Instantiate(collision.gameObject);
            newCube.transform.parent = transform;
            newCube.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
