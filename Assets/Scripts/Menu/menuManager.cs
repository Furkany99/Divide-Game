using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBttn,exitBttn;

    void FadeOut()
    {
        startBttn.GetComponent<CanvasGroup>().DOFade(1,0.8f);
        exitBttn.GetComponent<CanvasGroup>().DOFade(1,0.8f);
    }

    public void ExitGame()
    {
            Application.Quit();
    }
    void Start()
    {
        FadeOut();
    }

   public void StartGameLevel()
   {
       SceneManager.LoadScene("Game");
   }
    
}
