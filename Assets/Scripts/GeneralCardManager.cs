using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GeneralCardManager : MonoBehaviour
{
    public GameObject GeneralCard;
    private GameController _gameController;
    private void Start() {
        _gameController = FindObjectOfType<GameController>();
    }
    private void OnEnable() {
        GameController.OnDrawGeneralCard += SetGeneralCard;
        GameController.OnEndTurn += ManageEndTurn;
    }

    private void OnDisable() {
        GameController.OnDrawGeneralCard -= SetGeneralCard;
        GameController.OnEndTurn -= ManageEndTurn;
    }

    private void ManageEndTurn()
    {
        GeneralCard.SetActive(false);
    }

    private void SetGeneralCard()
    {
        GeneralCard.SetActive(true);
        GeneralCard.GetComponent<Image>().sprite = _gameController.PickGeneral();
    }
}
