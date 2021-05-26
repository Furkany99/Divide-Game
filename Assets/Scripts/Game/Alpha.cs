using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alpha : MonoBehaviour
{
    public GameObject alpha1;


    void Start()
    {
        alpha1.GetComponent<CanvasGroup>().DOFade(0,2f);
    }

 
    
}
