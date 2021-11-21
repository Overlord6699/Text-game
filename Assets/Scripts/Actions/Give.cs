using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (controller.player.HasItemByName(noun))
        {
            if (GiveToItem(controller, controller.player.currentLocation.items, noun))
            {
                return;
            }

            controller.currentText.text = "Nobody is interested in " + noun;
            return;
        }

        controller.currentText.text = "You don't have " + noun;
    }

    private bool GiveToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanGiveToItem(controller, item))
                {
                    if (item.interactionWith(controller, "give"))
                    {
                        controller.player.inventory.Remove(item);
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
