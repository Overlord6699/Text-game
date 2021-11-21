using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Actions
{
    public override void RespondToInput(GameController controller, string verb)
    {
        if(controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "You have nothing";
            return;
        }

        bool first = true;
        string result = "You have ";
        foreach(Item item in controller.player.inventory)
        {
            if (!first)
            {
                result += ", ";
            }
            result += "a " + item.itemName;
            first = false;
        }
        controller.currentText.text = result;
    }
}
