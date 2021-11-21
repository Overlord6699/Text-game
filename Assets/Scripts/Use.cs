using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        /* if (UseItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        } */
        if (UseItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "There is no " + noun;
    }

    private bool UseItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if(controller.player.CanUseItem(controller, item))
                {
                    if (item.interactionWith(controller, "use"))
                    {
                        controller.player.inventory.Remove(item);
                        return true;
                    }
                }

                controller.currentText.text = "The " + noun + " does nothing";
                return true;
            }
        }

        return false;
    }
}
