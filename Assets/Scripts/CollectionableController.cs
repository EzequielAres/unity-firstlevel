using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableController : MonoBehaviour
{

    public int collectionableScore;
    public AudioClip scoreSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().IncreaseScore(collectionableScore);
            collision.GetComponent<AudioSource>().PlayOneShot(scoreSound);

            Destroy(gameObject);
        }   
    }
}
