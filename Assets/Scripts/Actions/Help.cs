using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Actions
{
    public override void RespondToInput(GameController controller, string verb)
    {
        controller.currentText.text = "Type a Verd followed by a noun (e.g. \"Go North\")";
        controller.currentText.text += "\nAllowed verbs: \nGo, Use, Get, Give, Examine, Inventory, TalkTo, Say, Read, Help";
    }
}
