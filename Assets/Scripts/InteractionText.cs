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

    public float textSpeed = 0.06f;
    Coroutine runningCoroutine;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    //private void Update()
    //{
        
    //}

    IEnumerator DisplayTextCharacterByCharacter()
    {
        while (true)
        {
            elapsed += Time.deltaTime + textSpeed;
            int len = (int)(elapsed * charPerSecond);
            if (len > _text.Length)
                len = _text.Length;
            else
                GetComponent<AudioSource>().Play();
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
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
