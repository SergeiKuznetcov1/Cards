using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
public class BottomCardsManager : MonoBehaviour
{
    public GameController GameController;
    public GameObject PlayerPrefab;
    public TMP_Text CurrentPlayerTurn;
    private List<GameObject> _listOfPlayers = new();
    private void OnEnable() {
        StartGameBtn.OnGameStart += InstantiatePlayers;
        GameController.OnEndTurn += ManageEndTurn;
    }

    private void OnDisable() {
        StartGameBtn.OnGameStart -= InstantiatePlayers;
        GameController.OnEndTurn -= ManageEndTurn;
    }

    private void ManageEndTurn()
    {
        _listOfPlayers[GameController.CurrentPlayerTurn - 1].SetActive(false);
        if (GameController.CurrentPlayerTurn + 1 <= GameController.NumberOfPlayers) {
            GameController.CurrentPlayerTurn += 1;
        }
        else {
            GameController.CurrentPlayerTurn = 1;
        }
        _listOfPlayers[GameController.CurrentPlayerTurn - 1].SetActive(true);
        CurrentPlayerTurn.text = GameController.PlayersNames[GameController.CurrentPlayerTurn - 1];
    }

    private void InstantiatePlayers() {
        for (int i = 0; i < GameController.NumberOfPlayers; i++) {
            GameObject player = Instantiate(PlayerPrefab, this.transform);
            _listOfPlayers.Add(player);
        }
        CurrentPlayerTurn.text = GameController.PlayersNames[0];
        _listOfPlayers[0].SetActive(true);
    }
}
