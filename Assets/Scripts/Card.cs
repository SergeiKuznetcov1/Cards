using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public Image CardShine;
    public CardColor CardColor;
    public static Action<Sprite> OnCardClick; 

    public void OnCardClicked() {
        OnCardClick?.Invoke(GetComponent<Image>().sprite);
    }

    public void ActivateShine() {
        CardShine.enabled = true;
    }

    public void DeactivateShine() {
        CardShine.enabled = false;
    }

    //  int UILayer;
 
    // private void Start()
    // {
    //     UILayer = LayerMask.NameToLayer("Card");
    // }
 
    // private void Update()
    // {
    //     print(IsPointerOverUIElement() ? "Over UI" : "Not over UI");
    // }
 
 
    // //Returns 'true' if we touched or hovering on Unity UI element.
    // public bool IsPointerOverUIElement()
    // {
    //     return IsPointerOverUIElement(GetEventSystemRaycastResults());
    // }
 
 
    // //Returns 'true' if we touched or hovering on Unity UI element.
    // private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    // {
    //     for (int index = 0; index < eventSystemRaysastResults.Count; index++)
    //     {
    //         RaycastResult curRaysastResult = eventSystemRaysastResults[index];
    //         if (curRaysastResult.gameObject.layer == UILayer)
    //             return true;
    //     }
    //     return false;
    // }
 
 
    // //Gets all event system raycast results of current mouse or touch position.
    // static List<RaycastResult> GetEventSystemRaycastResults()
    // {
    //     PointerEventData eventData = new PointerEventData(EventSystem.current);
    //     eventData.position = Input.mousePosition;
    //     List<RaycastResult> raysastResults = new List<RaycastResult>();
    //     EventSystem.current.RaycastAll(eventData, raysastResults);
    //     return raysastResults;
    // }
}

public enum CardColor {
    Green, Blue, Orange, Violet, Yellow
}