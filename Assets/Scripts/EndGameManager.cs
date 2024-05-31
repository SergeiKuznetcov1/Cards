using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject PlayerDataPrefab;
    public GameController GameController;
    void Start()
    {
        ShowStats();
    }

    private void ShowStats() {
        for (int i = 0; i < GameController.NumberOfPlayers; i++) {
            GameObject playerData = Instantiate(PlayerDataPrefab, this.transform);
            PlayerInfoManager playerInfoManager = playerData.GetComponent<PlayerInfoManager>();
            playerInfoManager.PlayerNumberText.text = GameController.PlayersNames[i];
            for (int j = 0; j < 5; j++) {
                CardColor cardColor = CardColor.Green;
                if (j == 0) { cardColor = CardColor.Green; }
                if (j == 1) { cardColor = CardColor.Blue; }
                if (j == 2) { cardColor = CardColor.Orange; }
                if (j == 3) { cardColor = CardColor.Violet; }
                if (j == 4) { cardColor = CardColor.Yellow; }
                int curCardColor = SaveSystem.GetPlayerColorValue(i + 1, cardColor);
                playerInfoManager.ColorInfo[j].text = curCardColor.ToString();
                playerInfoManager.ColorImages[j].fillAmount = (float)curCardColor / 100 * (GameController.NumberOfPlayers + 1);
            }
        }
    }
}
