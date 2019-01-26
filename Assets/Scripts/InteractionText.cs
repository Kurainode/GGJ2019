using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public float charPerSecond;
    public float timeAtEnd;
    public bool ended;
    public string TextToDisplay
    {
        get
        {
            return _text;
        }

        set
        {
            _text = value;
            ended = false;
            elapsed = 0.0f;
        }
    }
    string _text = "";
    Text textComponent;
    float elapsed;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        int len = (int)(elapsed * charPerSecond);
        if (len > _text.Length)
            len = _text.Length;
        if (elapsed * charPerSecond >= _text.Length + timeAtEnd * charPerSecond)
        {
            textComponent.text = "";
            ended = true;
        }
        else
        {
            textComponent.text = _text.Substring(0, len);
            ended = false;
        }
    }
}
