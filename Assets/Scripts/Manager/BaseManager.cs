using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager : MonoBehaviour
{
    public static BaseManager GetInstance { get; protected set; }
    private void Awake()
    {
        if (GetInstance == null) GetInstance = this;
    }

    private void Start()
    {
        OnStart();
    }

    public virtual void OnEndGame()
    {
    }

    public virtual void OnPause()
    {
    }

    public virtual void OnResume()
    {
    }

    public virtual void OnStart()
    {
    }
}
