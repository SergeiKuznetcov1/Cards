using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;
public class vkEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ShowVirtualKeyboard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void ShowVirtualKeyboard(){
        if (YandexGame.EnvironmentData.isMobile) {
        }
        TNVirtualKeyboard.instance.ShowVirtualKeyboard();
        TNVirtualKeyboard.instance.targetText = gameObject.GetComponent<TMP_InputField>();
	}
}
