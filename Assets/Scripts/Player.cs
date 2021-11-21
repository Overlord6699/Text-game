using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;

    //моё
    public List<Item> hinInventory = new List<Item>();
    public List<Item> neroInventory = new List<Item>();
    
    public List<Item> inventory = new List<Item>();
    public bool ChangeLocation(GameController controller, string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if(connection != null)
        {
            if (connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Location dest)
    {
        currentLocation = dest;
    }

    public bool HasItemByName(string noun)
    {
        foreach(Item item in inventory)
        {
            if(noun.ToLower() == item.itemName.ToLower())
            {
                return true;
            }
        }

        return false;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if(item.targetItem == null)
        {
            return true;
        }

        if (HasItem(item.targetItem))
        {
            return true;
        }

        if (currentLocation.HasItem(item.targetItem))
        {
            return true;
        }

        return false;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    private bool HasItem(Item neededItem)
    {
        foreach(Item item in inventory)
        {
            if(neededItem == item && item.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }

    internal bool CanReadItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
        {
            return true;
        }

        if (HasItem(item.targetItem) && item.playerCanRead)
        {
            return true;
        }

        if (currentLocation.HasItem(item.targetItem) && item.playerCanRead)
        {
            return true;
        }

        return false;
    }

}
