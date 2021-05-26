using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    public void oyunaYenidenBasla()
    {
        SceneManager.LoadScene("Game");
    }

    public void anaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }

}
