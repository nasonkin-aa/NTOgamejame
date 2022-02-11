using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPastController : MonoBehaviour
{
    private GameObject _copyObject;
    public bool _isCopy = false;
    public bool _pastIsPosiple = true;
    private bool _isEnter = false;
    private Collider2D collisionOnEnter;
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    NewMethod(collision);

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
            return;

        _isEnter = true;
        collisionOnEnter = collision;
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        _isEnter = false;
        collisionOnEnter = null;

        transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 1f, 0.7f, 0.5f);

        _pastIsPosiple = true;
    }

    private void NewMethod(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 1f, 0.7f, 0.5f);
        _pastIsPosiple = true;





        if (Input.GetKeyDown(KeyCode.Z) && !transform.parent.GetComponent<MainCPController>().Iscopy)
        {
            CopyObjects(collision);
            _isCopy = true;
        }

        if (_isCopy)
        {
            _pastIsPosiple = false;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void CopyObjects(Collider2D collision)
    {
        GameObject newCube = GameObject.Instantiate(collision.gameObject);
        _copyObject = newCube;
        newCube.transform.GetComponent<BoxCollider2D>().enabled = false;
        newCube.transform.GetComponent<SpriteRenderer>().color = new Color(0.7f, 1f, 0.7f, 0.5f);
        newCube.transform.parent = transform;
        newCube.transform.localPosition = new Vector3(0, 0, 0);
        Debug.Log(_copyObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && _copyObject != null && transform.parent.GetComponent<MainCPController>().PastIspisible)
        {
            PastObjects();
            _isCopy = false;
        }

        if (_isEnter)
            NewMethod(collisionOnEnter);
    }

    private void PastObjects()
    {
        GameObject newCube = GameObject.Instantiate(_copyObject);
        newCube.transform.GetComponent<BoxCollider2D>().enabled = true;
        newCube.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        newCube.transform.localScale = new Vector3(1, 1, 0);
        newCube.transform.position = transform.position;

        Destroy(_copyObject);
    }
}


