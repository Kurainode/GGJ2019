using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechDisplayer : MonoBehaviour
{
    public GameObject textModel;
    public Transform interactionTextContainer;
    InteractionText interactionText;
    public string Text
    {
        set
        {
            _text = value;
            interactionText.TextToDisplay = value;
        }
    }
    string _text;

    private void Awake()
    {
        GameObject interactionTextGO = Instantiate(textModel);
        interactionTextGO.transform.SetParent(interactionTextContainer);
        interactionTextGO.transform.localScale = new Vector3(1, 1, 1);
        interactionText = interactionTextGO.GetComponent<InteractionText>();
    }

    private void Update()
    {
        interactionText.transform.position = new Vector3(transform.position.x, transform.position.y + GetComponent<Renderer>().bounds.extents.y + 0.5f, 0.0f);
    }
}
