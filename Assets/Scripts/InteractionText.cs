using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public float charPerSecond;
    public float timeAtEnd;
    public bool ended;
    public bool manual;
    public bool allDisplayed;
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
            allDisplayed = false;
            elapsed = 0.0f;

            if (runningCoroutine != null)
            {
                StopCoroutine(runningCoroutine);
            }
            runningCoroutine = StartCoroutine(DisplayTextCharacterByCharacter());
        }
    }
    string _text = "";
    Text textComponent;
    float elapsed;
    Coroutine runningCoroutine;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    IEnumerator DisplayTextCharacterByCharacter()
    {
        while (true)
        {
            elapsed += Time.deltaTime + 1.0f / charPerSecond;
            int len = (int)(elapsed * charPerSecond);
            if (len > _text.Length || allDisplayed)
            {
                len = _text.Length;
                allDisplayed = true;
            }
            else
                GetComponent<AudioSource>().Play();
            if (elapsed * charPerSecond >= _text.Length + timeAtEnd * charPerSecond && !manual)
            {
                textComponent.text = "";
                ended = true;
            }
            else
            {
                textComponent.text = _text.Substring(0, len);
                if (!manual)
                    ended = false;
            }
            if (allDisplayed)
            {
                textComponent.text = _text;
            }
            if (ended == true)
            {
                textComponent.text = "";
            }
            yield return new WaitForSeconds(1.0f / charPerSecond);
        }
    }
}
