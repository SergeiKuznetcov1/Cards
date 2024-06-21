using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurnCountHandler : MonoBehaviour
{
    public TMP_Text TurnCountNumber;
    private int _currentTurnCount = 1;
    private void OnEnable() {
        GameController.OnEndTurn += IncreaseTurnCount;
    }

    private void OnDisable() {
        GameController.OnEndTurn -= IncreaseTurnCount;
    }

    private void IncreaseTurnCount()
    {
        _currentTurnCount += 1;
        TurnCountNumber.text = _currentTurnCount.ToString();
    }
}
