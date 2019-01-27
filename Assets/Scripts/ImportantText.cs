using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportantText : MonoBehaviour
{
    public string currentCharacter;
    bool choice = false;
    public Text choice1;
    public Text choice2;
    public InteractionText interactionText;
    public Image ghostAvatar;
    public Image playerAvatar;
    public int selectedChoice = 1;

    public void DisplayText(string character, string text)
    {
        ghostAvatar.gameObject.SetActive(false);
        playerAvatar.gameObject.SetActive(false);
        if (character == "Ghost")
        {
            ghostAvatar.gameObject.SetActive(true);
        }
        else if (character == "Player")
        {
            playerAvatar.gameObject.SetActive(true);
        }
        interactionText.TextToDisplay = text;
        choice = false;
        choice1.text = "";
        choice2.text = "";
        StartCoroutine("TextInteraction");
    }

    public void DisplayText(string character, string text, string choice1Text, string choice2Text)
    {
        DisplayText(character, text);
        choice = true;
        choice1.text = choice1Text;
        choice2.text = choice2Text;
    }

    IEnumerator TextInteraction()
    {
        GameObject.Find("EventSystem").GetComponent<EventDispatcher>().paused = true;
        bool sameFrame = true;
        interactionText.ended = false;
        while (sameFrame || !Input.GetButtonDown("Action"))
        {
            if (Input.GetAxis("Horizontal") > 0.5f)
            {
                selectedChoice = 2;
            }
            else if (Input.GetAxis("Horizontal") < -0.5f)
            {
                selectedChoice = 1;
            }
            if (selectedChoice == 1)
            {
                choice1.color = new Color(1, 1, 1, 1);
                choice2.color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                choice2.color = new Color(1, 1, 1, 1);
                choice1.color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            sameFrame = false;
            yield return null;
        }
        GameObject.Find("EventSystem").GetComponent<EventDispatcher>().paused = false;
        interactionText.ended = true;
    }
}
