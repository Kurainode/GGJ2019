using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher : MonoBehaviour
{
    public ImportantText importantText;
    public bool paused;

    public void Talk(ItemBehaviour.JsonData data)
    {
        if (data.important)
        {
            importantText.gameObject.SetActive(true);
            if (!data.haveChoice)
                importantText.DisplayText(data.emmiter, data.caption);
            else
                importantText.DisplayText(data.emmiter, data.caption, data.choice1, data.choice2);
        }
        else
        {
            GameObject characterGO = GameObject.Find(data.emmiter);
            if (characterGO)
            {
                var speechDisplayer = characterGO.GetComponent<SpeechDisplayer>();
                speechDisplayer.Text = data.caption;
            }
        }

        if (string.IsNullOrEmpty(data.trigger) == false)
        {
            GetComponent<GlobalMessageEventSender>().GlobalMessage(data.trigger);
        }
    }
}
