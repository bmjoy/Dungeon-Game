using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    [SerializeField] GameObject _defeatMenuObjects;
    [SerializeField] Canvas _touchInputCanvas;

    public void ShowDefeatMenu()
    {
        Invoke("PauseOnDelay", 4f);
    }

    void PauseOnDelay()
    {
        Time.timeScale = 0;
        _defeatMenuObjects.SetActive(true);
        _touchInputCanvas.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        _defeatMenuObjects.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
