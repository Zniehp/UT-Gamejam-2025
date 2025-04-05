using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    [SerializeField]
    private TextData day1Morning;
    [SerializeField]
    private TextData day1Night;
    [SerializeField]
    private TextData day2Morning;
    [SerializeField]
    private TextData day2Night;
    [SerializeField]
    private TextData day3Morning;
    [SerializeField]
    private TextData day3Night;

    public GameObject mainText;
    private TMP_Text text;


    private void Awake()
    {
        text = mainText.GetComponentInChildren<TMP_Text>();
    }
    public void Show1Morning()
    {
        text.text = day1Morning.text;
    }
    public void Show1Night()
    {
        text.text = day1Night.text;
    }

    public void Show2Morning()
    {
        text.text = day2Morning.text;
    }
    public void Show2Night()
    {
        text.text = day2Night.text;
    }

    public void Show3Morning()
    {
        text.text = day3Morning.text;
    }
    public void Show3Night()
    {
        text.text = day3Night.text;
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
