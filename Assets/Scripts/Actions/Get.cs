using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach(Item item in controller.player.currentLocation.items)
        {
            if (item.itemEnabled && item.itemName == noun)
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "You take the " + noun;
                }else // я добавил ( I changed this to give response when I can't get the item)
                {
                    controller.currentText.text = "You can't get that";
                }

                item.interactionWith(controller, "get");
                return;
            }
            else
            {
                controller.currentText.text = "There is no " + noun;
            }
        }
    }
}
