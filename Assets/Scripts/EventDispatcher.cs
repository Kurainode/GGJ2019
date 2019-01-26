using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher : MonoBehaviour
{
    public void Talk(string character, string text, bool important)
    {
        if (important)
        {

        }
        else
        {
            GameObject characterGO = GameObject.Find(character);
            if (characterGO)
            {
                var speechDisplayer = characterGO.GetComponent<SpeechDisplayer>();
                speechDisplayer.Text = text;
            }
        }
    }
}
