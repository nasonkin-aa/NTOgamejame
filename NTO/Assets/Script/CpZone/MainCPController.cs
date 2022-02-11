using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCPController : MonoBehaviour
{
    public bool PastIspisible = true;
    public bool Iscopy = false;
    public void PastOn()
    {

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
        }
        foreach (Transform child in transform)
        {
       
            if (child.GetComponent<CopyPastController>()._isCopy)
            {
                Iscopy = true;
                break;
            }
            Iscopy = false;
        }
    }
}
