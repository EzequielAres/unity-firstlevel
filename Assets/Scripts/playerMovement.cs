using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public int speed;
    public int jumpForce;
    private Rigidbody2D physics;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float movementx = Input.GetAxis("Horizontal");
        physics.velocity = new Vector2(movementx * speed, physics.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TouchingGround()) {
            physics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }

    private bool TouchingGround(){

        RaycastHit2D touching = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.1f);

        return touching.collider != null;
    }
}
