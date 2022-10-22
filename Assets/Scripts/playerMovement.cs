using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public int speed;
    public int jumpForce;
    private Rigidbody2D physics;
    private SpriteRenderer sprite;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float movementx = Input.GetAxis("Horizontal");
        physics.velocity = new Vector2(movementx * speed, physics.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && TouchingGround()) {
            physics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (physics.velocity.x > 0) sprite.flipX = false;
        if (physics.velocity.x < 0) sprite.flipX = true;

        animatePlayer();
    }

    private void animatePlayer()
    {
        if (!TouchingGround())
        {
            animator.Play("PlayerJump");
        } else if ((physics.velocity.x > 0 || physics.velocity.x < -1) && physics.velocity.y == 0)
        {
            animator.Play("PlayerRunning");
        } else if ((physics.velocity.x > -1 || physics.velocity.x < 1) && physics.velocity.y == 0)
        {
            animator.Play("PlayerIdle");
        }
    }

    private bool TouchingGround(){

        RaycastHit2D touching = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.1f);

        return touching.collider != null;
    }

    public void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
