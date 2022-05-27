using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
        Invoke("buttonOn", 3);
    }

    void buttonOn()
    {
        this.gameObject.SetActive(true);
    }

    public void clickBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
