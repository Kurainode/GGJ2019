using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public float charPerSecond;
    public float timeAtEnd;
    public List<string> TextToDisplay
    {
        get
        {
            return _textArray;
        }

        set
        {
            _textArray = value;
            textIndex = 0;
            elapsed = 0.0f;
        }
    }
    List<string> _textArray;
    int textIndex;
    Text textComponent;
    float elapsed;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        TextToDisplay = new List<string>{ "This object is really incredible", "This is another text", "Yet another" };
    }

    private void Update()
    {
        if ((elapsed * charPerSecond >= _textArray[textIndex].Length + timeAtEnd * charPerSecond) && (textIndex < _textArray.Count - 1))
        {
            elapsed = 0.0f;
            ++textIndex;
        }
        elapsed += Time.deltaTime;
        int len = (int)(elapsed * charPerSecond);
        if (len > _textArray[textIndex].Length)
            len = _textArray[textIndex].Length;
        if ((elapsed * charPerSecond >= _textArray[textIndex].Length + timeAtEnd * charPerSecond) && (textIndex >= _textArray.Count - 1))
        {
            textComponent.text = "";
        }
        else
        {
            textComponent.text = _textArray[textIndex].Substring(0, len);
        }
    }
}
