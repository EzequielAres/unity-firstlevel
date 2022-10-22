using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{

    private SpriteRenderer sprite;
    private float beforeXPosition;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        beforeXPosition = transform.parent.position.x;
        sprite = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateEnemy();

        sprite.flipX = beforeXPosition < transform.position.x;

        beforeXPosition = transform.position.x;
    }
    private void AnimateEnemy()
    {
        if (transform.position.x > -1 && transform.position.x < 1)
        {
            animator.Play("Enemy2Idle");
        }
        else if (transform.position.x < 0 || transform.position.x > 0)
        {
            animator.Play("Enemy2Running");
        }
    }
}
