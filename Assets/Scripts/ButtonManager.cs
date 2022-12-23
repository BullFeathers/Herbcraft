using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void goToGame() {
        SceneManager.LoadScene("Start");
    }

    public void goToEncyclopedia() 
    {
        SceneManager.LoadScene("Encyclopedia");
    }
}
