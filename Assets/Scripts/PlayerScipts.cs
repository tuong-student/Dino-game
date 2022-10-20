using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScipts : MonoBehaviour
{
    public float jumpForce;
    public bool isGround;
    bool isCrouch;
    public Vector3 crouchScale;
    Vector3 originalScale;

    #region Components
    Rigidbody2D myBody;
    #endregion

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        originalScale = this.transform.localScale;
    }

    private void Update()
    {
        if (GameManager.GetInstance.isEndGame) return;
        if(Input.GetAxisRaw("Vertical") > 0 && isGround)
        {
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            isCrouch = true;
            this.transform.localScale = crouchScale;
        }
        else
        {
            isCrouch = false;
            this.transform.localScale = originalScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            myBody.gravityScale = 1;
            PopAnimation(0.1f);
            isGround = true;
        }

        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            myBody.gravityScale = 0;
            myBody.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            GameManager.GetInstance.OnEndGame();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            myBody.gravityScale = 3;
        }
    }

    void PopAnimation(float duration)
    {
        if (!isGround)
        {
            this.transform.DOScaleX(1f, duration).SetEase(Ease.OutBack);
            this.transform.DOScaleY(1f, duration).SetEase(Ease.OutBack);
        }
    }
}
