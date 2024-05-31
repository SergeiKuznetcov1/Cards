using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    private float _elapsedTime;
    private void Update() {
            _elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);
            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
