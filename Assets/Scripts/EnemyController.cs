using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int speed;
    public Vector3 endPosition;

    private Vector3 startPosition;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 targetPosition = (isMoving) ? endPosition : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition) isMoving = !isMoving;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().LoseLive();
        }
    }

}
