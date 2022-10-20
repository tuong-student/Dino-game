using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main GetInstance { get; private set; }
    public bool isIntro;

    private void Awake()
    {
        if (GetInstance == null) GetInstance = this;
        isIntro = true;
    }

    private void Start()
    {

    }

    public void OnStart()
    {
        isIntro = false;
        LoadResource("MainGame/Manager/MapManager");
    }

    void LoadResource(string path)
    {
        Instantiate(Resources.Load(path));
    }
}
