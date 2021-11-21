using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(CheckItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }
        if(CheckItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "You can't see a " + noun;
    }

    private bool CheckItems(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName == noun)
            {
                if (item.interactionWith(controller, "examine"))
                {
                    return true;
                }
                controller.currentText.text = item.description;
                return true;
            }
        }

        return false;
    }
}
