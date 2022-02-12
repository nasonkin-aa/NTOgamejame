using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCPController : MonoBehaviour
{
    public bool PastIspisible = true;
    public bool Iscopy = false;

    public bool CopyOn = false;
    public bool PastOn = false;

    public GameObject ButtonC;
    public GameObject ButtonP;
    public void Copy()
    {
        CopyOn = true;
        if (Iscopy)
        {

            
        }
        StartCoroutine(Dilay());
    }
    public void Past()
    {

        PastOn = true;
        if (PastIspisible)
        {
           
        }
        StartCoroutine(DilayPast());
    }
    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(0.2f);
        CopyOn = false;
    }
    private IEnumerator DilayPast()
    {
        yield return new WaitForSeconds(0.2f);
        PastOn = false;
    }
    private void Update()
    {
        PastIspisible = true;
        foreach(Transform child in transform)
        {
            if (!child.GetComponent<CopyPastController>()._pastIsPosiple)
            {
                PastIspisible = false;

                break;
            }
            PastIspisible = true;
            ButtonC.SetActive(true);
            ButtonP.SetActive(false);
        }
        foreach (Transform child in transform)
        {
       
            if (child.GetComponent<CopyPastController>()._isCopy)
            {
                Iscopy = true;
                ButtonC.SetActive(false);
                ButtonP.SetActive(true);

                break;
            }
            Iscopy = false;
        }
    }

}
