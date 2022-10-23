using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : MonoBehaviour
{
    private bool win;
    private int score;

    public int Score { get => score; set => score = value; }
    public bool Win { get => win; set => win = value; }

    private void Awake()
    {
        int instanceNum = FindObjectsOfType<GameDataController>().Length;

        if (instanceNum != 1)
        {
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
