using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevelController : MonoBehaviour
{

    public TextMeshProUGUI endLevelText;

    private GameDataController gameData;

    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameDataController>();
        
        string endMessage = (gameData.Win) ? "Has ganado!" : "Has perdido";
        
        if (gameData.Win) endMessage += " Puntuación: " + gameData.Score;

        endLevelText.text = endMessage;
    }
}
