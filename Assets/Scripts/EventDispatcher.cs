using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher : MonoBehaviour
{
    void Talk(string character, List<string> text, bool important)
    {
        if (important)
        {

        }
        else
        {
            GameObject characterGO = GameObject.Find(character);
            
        }
    }
}
