using System.Collections.Generic;
using System.Collections;

using UnityEngine;

//This class controls the dialog events which are added to a certain queue in a certain day.
//This events are optional ad controlled by the user
public class DialogEventManager : MonoBehaviour
{

    //Contains the optional dialog events for each day
    public readonly Dictionary<int, List<DialogEvent>> optionalDialogEvents = new Dictionary<int, List<DialogEvent>>();

    //Called from a game event within the tag parser
    public void AddOptionalDialogEvent(DialogEvent dialogEvent) {
        Debug.Log("Added new dialog progression to the end of " + dialogEvent.queue + " queue for day: " + dialogEvent.day);
        if(optionalDialogEvents.ContainsKey(dialogEvent.day)) {
            optionalDialogEvents[dialogEvent.day].Add(dialogEvent);
        }
        else {
            optionalDialogEvents.Add(dialogEvent.day, new List<DialogEvent>{dialogEvent});
        }
    }
}
