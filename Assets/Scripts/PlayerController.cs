using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpSpeed;
    public float horizontal;
    public float jump;
    public bool hasJump;
    public int jumpCount;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        hasJump = true;
        jumpCount = 0;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");

        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocityY);

        // flip character
        if (horizontal < -0.01f)
            transform.localScale = Vector3.one;
        else if (horizontal > 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump"))
        {
            if (hasJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jump * jumpSpeed);
                hasJump = false;
                jumpCount++;
            }
        }
        if (jumpCount <= 1)
            hasJump = true;
        else
            hasJump = false;


        rb.freezeRotation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("platform") || collision.gameObject.name.Contains("Platform"))
            hasJump = true;

        if (collision.gameObject.name == "Flag")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (collision.gameObject.name.Contains("Bird"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        jumpCount = 0;
        
    }
}
