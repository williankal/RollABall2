using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void OnMenuButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
