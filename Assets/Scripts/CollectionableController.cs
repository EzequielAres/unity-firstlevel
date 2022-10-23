using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableController : MonoBehaviour
{

    public int collectionableScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().IncreaseScore(collectionableScore);
            Destroy(gameObject);
        }   
    }
}
