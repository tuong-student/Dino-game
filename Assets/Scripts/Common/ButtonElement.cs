using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class ButtonElement : MonoBehaviour
{
    public Text btnText;
    public Image btnImage;
    public Button button;
    Action action;

    private void OnEnable()
    {
        this.transform.localScale = Vector3.zero;
        this.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }

    public void OnDisable()
    {
        this.transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            action?.Invoke();
        });
    }

    public void SetAction(Action action)
    {
        this.action = action;
    }

    public void SetBtnText(string text)
    {
        btnText.text = text;
    }

    public void SetBtnImage(Color color, Sprite image = null)
    {
        if (image)
        {
            btnImage.sprite = image;
            btnImage.color = color;
        }
        else btnImage.color = color;
    }
}
