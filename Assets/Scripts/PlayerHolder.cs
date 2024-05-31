using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHolder : MonoBehaviour
{
    public Transform Left;
    public Transform Right;
    public GameObject CardPrefab;
    private bool _firstEnabling = true;
    private GameController _gameController;
    private void OnEnable() {
        FirstTimeEnable();
        GameController.OnDrawPlayerCard += DrawCard;
    }

    private void OnDisable() {
        GameController.OnDrawPlayerCard -= DrawCard;
    }

    private void FirstTimeEnable() {
        if (_firstEnabling == false) {
            return;
        }
        _gameController = FindObjectOfType<GameController>();
        _firstEnabling = false;
        for (int i = 0; i < 2; i++) {
            GameObject card = Instantiate(CardPrefab, Left);
            (Sprite, CardColor) cardData = _gameController.PickProfession();
            card.GetComponent<Image>().sprite = cardData.Item1;
            card.GetComponent<Card>().CardColor = cardData.Item2;
        }
        for (int i = 0; i < 2; i++) {
            GameObject card = Instantiate(CardPrefab, Right);
            (Sprite, CardColor) cardData = _gameController.PickProfession();
            card.GetComponent<Image>().sprite = cardData.Item1;
            card.GetComponent<Card>().CardColor = cardData.Item2;
        }
    }

    private void DrawCard()
    {
        if (Left.childCount < 2) {
            GameObject card = Instantiate(CardPrefab, Left);
            (Sprite, CardColor) cardData = _gameController.PickProfession();
            card.GetComponent<Image>().sprite = cardData.Item1;
            card.GetComponent<Card>().CardColor = cardData.Item2;
        }
        else if (Right.childCount < 2) {
            GameObject card = Instantiate(CardPrefab, Right);
            (Sprite, CardColor) cardData = _gameController.PickProfession();
            card.GetComponent<Image>().sprite = cardData.Item1;
            card.GetComponent<Card>().CardColor = cardData.Item2;
        }
    }
}
