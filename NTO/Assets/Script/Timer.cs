using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeS = 60f;
    public float timeH = 24f;
    public Text texts;
    public Text texth;

    void Start()
    {
        texts.text = timeS.ToString();
        texth.text = timeH.ToString();
    }

    void FixedUpdate()
    {
        if (timeS > 0)
        {
            timeS -= Time.deltaTime * 30;
            texts.text = Mathf.Round(timeS).ToString();
        }
        else if(timeH > 0)
        {
            timeS = 60f;
            timeH--;
            texth.text = Mathf.Round(timeH).ToString();

        }
        else
        {
            Debug.Log("dued");
        }
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
}