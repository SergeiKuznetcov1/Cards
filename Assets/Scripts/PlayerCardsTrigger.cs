using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardsTrigger : MonoBehaviour
{
    public int PlayerIndex;
    public static Action<int> OnShowPlayerCards;
    public void ShowPlayerCards() {
        OnShowPlayerCards?.Invoke(PlayerIndex);
    }
}
