using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject panel_quit;
    void Start()
    {
        panel_quit.SetActive(false);
    }
	public void StartGame()
    {
        SceneManager.LoadScene("scene1");
    }

    public void OpenQuitPanel()
    {
        panel_quit.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CancelQuit()
    {
        panel_quit.SetActive(false);
    }
}
