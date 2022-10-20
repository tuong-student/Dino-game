using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GetInstance { get; private set; }
    public bool isEndGame = false;


    private void Awake()
    {
        if (GetInstance == null) GetInstance = this;
    }

    private void Start()
    {

    }

    public void OnStart()
    {
        Time.timeScale = 1;
        isEndGame = false;
        UIManager.GetInstance.OnStart();
        Main.GetInstance.OnStart();
    }

    public void OnEndGame()
    {
        isEndGame = true;
        UIManager.GetInstance.OnEndGame();
    }

    public void OnResume()
    {
        Time.timeScale = 1;
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
