using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class StartGameBtn : MonoBehaviour
{
    public GameObject StartScreenHolder;
    public GameObject GameScreenHolder;
    public GameController GameController;
    public TMP_Text NumberOfPlayersText;
    public TMP_Text StartScreenTopText;
    public TMP_InputField InputField;
    public Image BtnImage;
    public Sprite StartGameSprite;
    public static Action OnGameStart;
    private int _currentPlayer = 1;
    private int _playerNumber;
    public TNVirtualKeyboard VirtualKeyboard;
    public void StartGame() {
        if (GameController.NumberOfPlayers == 0) {
            string stringDigits = "";
            foreach (char c in NumberOfPlayersText.text) {
                if (Char.IsDigit(c)) {
                    stringDigits += c;
                }
            }
            if(stringDigits != "") {
                _playerNumber = Int32.Parse(stringDigits);
            }
            if (_playerNumber == 0) {
                _playerNumber = 1;
            }
            
        }
        if (GameController.PlayersNames.Count == 0 && GameController.NumberOfPlayers == 0) {
            GameController.NumberOfPlayers = _playerNumber;
            for (int i = 0; i < GameController.NumberOfPlayers; i++) {
                GameController.AllPlayersCardsPicked.Add(new List<Sprite>());
            }
            InputField.text = "";
            Debug.Log(InputField.text);
            StartScreenTopText.text = "Введите имя игрока " + _currentPlayer;
        }
        else if (_currentPlayer + 1 < GameController.NumberOfPlayers) {
            GameController.PlayersNames.Add(NumberOfPlayersText.text);
            _currentPlayer += 1;
            StartScreenTopText.text = "Введите имя игрока " + _currentPlayer;
            InputField.text = "";
        }
        else if (_currentPlayer + 1 == GameController.NumberOfPlayers) {
            GameController.PlayersNames.Add(NumberOfPlayersText.text);
            _currentPlayer += 1;
            StartScreenTopText.text = "Введите имя игрока " + _currentPlayer;
            InputField.text = "";
            BtnImage.sprite = StartGameSprite;
        }
        else {
            GameController.PlayersNames.Add(NumberOfPlayersText.text);
            StartScreenHolder.SetActive(false);
            GameScreenHolder.SetActive(true);
            VirtualKeyboard.HideVirtualKeyboard();
            OnGameStart?.Invoke();
        }
    }
}
