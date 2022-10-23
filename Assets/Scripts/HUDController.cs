using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI collectionablesText;

    public void SetLivesTxt(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void SetLeftTime(int time)
    {
        int sec = time % 60;
        int min = time / 60;

        timeText.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    public void SetLeftCollectionables(int count)
    {
        collectionablesText.text = "Left collectionables: " + count;
    }
}
