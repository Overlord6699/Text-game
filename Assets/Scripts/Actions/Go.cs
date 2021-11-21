using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(controller.player.ChangeLocation(controller, noun))
        {
            controller.DisplayLocation();
        }
        else
        {
            controller.currentText.text = "You can't go there!";
        }
    }
}
