using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string description;

    public bool playerCanTake;
    public bool itemEnabled = true;

    public Interaction[] interactions;
    public Item targetItem = null;
    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;
    public bool playerCanRead = false;

    public bool interactionWith(GameController controller, string actionKeyword, string phrase = "")
    {
        foreach(Interaction interaction in interactions)
        {
            if(interaction.action.keyword == actionKeyword)
            {
                if (phrase != "" && phrase.ToLower() != interaction.textToMatch.ToLower())
                    continue;

                foreach(Item disableItem in interaction.itemsToDisable)
                {
                    disableItem.itemEnabled = false;
                }

                foreach (Item enableItem in interaction.itemsToEnable)
                {
                    enableItem.itemEnabled = true;
                }

                foreach (Connection disableConnection in interaction.connectionsToDisable)
                {
                    disableConnection.connectionEnabled = false;
                }

                foreach (Connection enableConnection in interaction.connectionsToEnable)
                {
                    enableConnection.connectionEnabled = true;
                }

                if(interaction.teleportLocation != null)
                {
                    controller.player.Teleport(controller, interaction.teleportLocation);
                }

                if(interaction.response != "")
                    controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
            }
        }

        return false;
    }
}
