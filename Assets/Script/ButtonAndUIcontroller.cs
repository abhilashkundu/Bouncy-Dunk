using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAndUIcontroller : MonoBehaviour
{
    PointsAndSceneController pointsAndSceneController;
    private void Awake()
    {
        pointsAndSceneController = FindAnyObjectByType<PointsAndSceneController>();
    }
    public void OnMenu()
    {
        Time.timeScale = 1f;
        pointsAndSceneController.Reset();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        pointsAndSceneController.Reset();
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    public void OnFirstStart()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }
}
