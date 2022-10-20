using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    float time = 0;
    int oldPoint = 0;
    public static UIManager GetInstance { get; private set; }

    [SerializeField] Text pointText;
    [SerializeField] ButtonElement resumeBtn, exitBtn;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject introText;

    private void Awake()
    {
        if (GetInstance == null) GetInstance = this;
    }

    private void Start()
    {
        ShowPanel();
    }

    private void Update()
    {
        if (GameManager.GetInstance.isEndGame || Main.GetInstance.isIntro) return;
        time += Time.fixedDeltaTime;
        if((int)time - oldPoint == 1)
        {
            oldPoint += 1;
            SetPointText((int)oldPoint);
        }
    }

    public void OnEndGame()
    {
        ShowPanel();
    }

    public void OnResume()
    {
        HidePanel();
    }

    public void OnStart()
    {
        HidePanel();
        SetPointText(0);
        introText.SetActive(false);
    }

    public void SetPointText(int point)
    {
        pointText.text = point.ToString();
    }

    void ShowPanel()
    {
        gamePanel.transform.localScale = Vector3.one;
        gamePanel.SetActive(true);

        if (Main.GetInstance.isIntro)
        {
            resumeBtn.SetBtnText("Play");
            resumeBtn.SetAction(() =>
            {
                GameManager.GetInstance.OnStart();
            });
        }

        if (GameManager.GetInstance.isEndGame)
        {
            resumeBtn.SetBtnText("Restart");
            resumeBtn.SetAction(() =>
            {
                GameManager.GetInstance.OnRestart();
            });
        }

        exitBtn.SetAction(() =>
        {
            HidePanel();
            Application.Quit();
        });
    }

    void HidePanel()
    {
        gamePanel.transform.DOScale(0, 0.5f).SetEase(Ease.InBounce);
        gamePanel.SetActive(false);
    }
}
