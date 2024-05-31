using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static int GetPlayerColorValue(int player, CardColor cardColor) {
        return PlayerPrefs.GetInt($"Player{player}, color {cardColor}", 0);
    }

    public static void SetPlayerColorValue(int player, CardColor cardColor, int value) {
        PlayerPrefs.SetInt($"Player{player}, color {cardColor}", value);
    }
}
