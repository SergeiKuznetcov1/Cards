using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardsManager : MonoBehaviour
{
    public GameController GameController;
    public CanvasGroup CanvasGroup;
    public GameObject Content;
    public GameObject CardImageObj;
    public ScrollRect ScrollRect;
    private void OnEnable() {
        PlayerCardsTrigger.OnShowPlayerCards += ShowPlayerCards;
    }

    private void OnDisable() {
        PlayerCardsTrigger.OnShowPlayerCards -= ShowPlayerCards;
    }

    private void ShowPlayerCards(int playerIndex) {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        foreach (Transform child in Content.transform) {
            Destroy(child.gameObject);
        }
        ScrollRect.horizontalNormalizedPosition = 0;
        for (int i = 0; i < GameController.AllPlayersCardsPicked[playerIndex].Count; i++) {
            GameObject imageObj = Instantiate(CardImageObj, Content.transform);
            imageObj.GetComponent<Image>().sprite = GameController.AllPlayersCardsPicked[playerIndex][i];
        }
    }

    public void HidePlayerCards() {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }
}
