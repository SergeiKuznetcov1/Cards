using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject StartGameScreen;
    public GameObject SelectPlayerScreen;
    public GameObject AboutScreen;
    public GameObject InstructionScreen;
    public List<string> PlayersNames = new();
    public GameObject GeneralCard;
    public GameObject ProfessionCard;
    public Sprite[] GeneralCardsSprites;
    private List<int> _generalLeftIndexes = new();
    public Sprite[] ProfessionCardsSprites;
    private List<int> _professionLeftIndexes = new();
    public GameObject ShowCardInfoHolder;
    public Image CardImage;
    public static int CurrentPlayerTurn = 1; 
    public static int NumberOfPlayers;
    public static Action OnDrawPlayerCard;
    public static Action OnDrawGeneralCard;
    public static Action OnEndTurn;
    public GameObject GameScreenHolder;
    public GameObject EndScreenHolder;
    public List<List<Sprite>> AllPlayersCardsPicked = new();
    private void OnEnable() {
        Card.OnCardClick += SwitchCardInfoState;
    }

    private void OnDisable() {
        Card.OnCardClick -= SwitchCardInfoState;
    }

    private void Start() {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < ProfessionCardsSprites.Length; i++) {
            _professionLeftIndexes.Add(i);
        }
        for (int i = 0; i < GeneralCardsSprites.Length; i++) {
            _generalLeftIndexes.Add(i);
        }
    }

    private void SwitchCardInfoState(Sprite sprite) {
        ShowCardInfoHolder.SetActive(!ShowCardInfoHolder.activeSelf);
        CardImage.sprite = sprite;
    }
    
    public (Sprite, CardColor) PickProfession() {
        int randomCardIndex = Random.Range(0, _professionLeftIndexes.Count);
        int indexToUse = _professionLeftIndexes[randomCardIndex];
        CardColor cardColor;
        if (indexToUse >= 0 && indexToUse <= 16) {
            cardColor = CardColor.Green;
        }
        else if (indexToUse >= 17 && indexToUse <= 33) {
            cardColor = CardColor.Blue;
        }
        else if (indexToUse >= 34 && indexToUse <= 50) {
            cardColor = CardColor.Orange;
        }
        else if (indexToUse >= 51 && indexToUse <= 67) {
            cardColor = CardColor.Violet;
        }
        else {
            cardColor = CardColor.Yellow;
        }
        Sprite cardSprite = ProfessionCardsSprites[indexToUse]; 
        _professionLeftIndexes.RemoveAt(randomCardIndex);
        if (_professionLeftIndexes.Count == 0) {
            Image cardImage = ProfessionCard.GetComponent<Image>();
            ProfessionCard.GetComponent<Image>().color = new Color(cardImage.color.r, cardImage.color.g, cardImage.color.b, .5f);
            ProfessionCard.GetComponent<Button>().enabled = false;
        }
        return (cardSprite, cardColor);
    }

    public Sprite PickGeneral() {
        int randomCardIndex = Random.Range(0, _generalLeftIndexes.Count);
        int indexToUse = _generalLeftIndexes[randomCardIndex];
        Sprite cardSprite = GeneralCardsSprites[indexToUse]; 
        _generalLeftIndexes.RemoveAt(randomCardIndex);
        if (_generalLeftIndexes.Count == 0) {
            Image cardImage = GeneralCard.GetComponent<Image>();
            GeneralCard.GetComponent<Image>().color = new Color(cardImage.color.r, cardImage.color.g, cardImage.color.b, .5f);
            GeneralCard.GetComponent<Button>().enabled = false;

        }
        return cardSprite;
    }

    public void InvokeOnDrawPlayerCard() {
        OnDrawPlayerCard?.Invoke();
    }

    public void InvokeOnDrawGeneralCard() {
        OnDrawGeneralCard?.Invoke();
    }

    public void InvokeOnEndTurn() {
        OnEndTurn?.Invoke();
    }

    public void EndGame() {
        GameScreenHolder.SetActive(false);
        EndScreenHolder.SetActive(true);
    }

    public void ReloadGame() {
        PlayerPrefs.DeleteAll();
        CurrentPlayerTurn = 1; 
        PlayersNames.Clear();
        NumberOfPlayers = 0;
        SceneManager.LoadScene(0);
    }

    public void GoToFirstScreen() {
        AboutScreen.SetActive(false);
        InstructionScreen.SetActive(false);
        StartGameScreen.SetActive(true);
    }

    public void GoToAbout() {
        StartGameScreen.SetActive(false);
        AboutScreen.SetActive(true);
    }

    public void GoToInstruction() {
        StartGameScreen.SetActive(false);
        InstructionScreen.SetActive(true);
    }

    public void GoToSelectPlayerScreen() {
        StartGameScreen.SetActive(false);
        SelectPlayerScreen.SetActive(true);
    }

    public void ExitApplication() {
        Application.Quit();
    }
}
