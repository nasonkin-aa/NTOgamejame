using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] int _nextSceneNumber = 0;
    [SerializeField] private Transform _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == _player)
            SceneManager.LoadScene(_nextSceneNumber);
    }
}
