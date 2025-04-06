using System.Collections;
using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    public GameObject mainText;
    private TMP_Text text;
    public TextData currentText;
    private int currentTextIndex;
    public NextButtonScript nextButtonScript;

    private void Awake()
    {
        text = mainText.GetComponentInChildren<TMP_Text>();
        ShowText();
        nextButtonScript.CheckStoryState();
    }
    public void UpdateText()
    {
        text.text = $"{currentText.text}";
    }

    public void ShowText()
    {
        mainText.SetActive(true);
    }

    public void HideText()
    {
        mainText.SetActive(false);
    }
}
