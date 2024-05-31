using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool SaveSlot;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) {
            if (SaveSlot == true) {
                CardColor cardColor = eventData.pointerDrag.GetComponent<Card>().CardColor;
                int curValue = SaveSystem.GetPlayerColorValue(GameController.CurrentPlayerTurn, cardColor);
                SaveSystem.SetPlayerColorValue(GameController.CurrentPlayerTurn, cardColor, curValue + 1);
            }
            Destroy(eventData.pointerDrag);
        } 
    }
}
