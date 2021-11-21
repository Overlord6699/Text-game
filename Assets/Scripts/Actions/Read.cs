using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }
        if (ReadItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "There is no " + noun;
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.interactionWith(controller, "read"))
                    {
                        return true;
                    }
                }

                controller.currentText.text = "There is nothing to read on the " + noun;
                return true;
            }
        }

        return false;
    }


}

