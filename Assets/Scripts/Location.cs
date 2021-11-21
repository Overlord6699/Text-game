using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    public bool isHinMainChar = false; // моё

    [TextArea]
    public string description;
    public List<Item> items = new List<Item>();
    public Connection[] connections;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItemsText()
    {
        int counter = 0;

        if(items.Count == 0)
        {
            return "";
        }
        else
        {
            bool first = true;
            string result = "You see ";
            foreach(Item item in items)
            {
                if (item.itemEnabled)
                {
                    if (!first)
                    {
                        result += " and ";
                    }
                    result += item.description;
                    first = false;
                }
                else
                {
                    counter++;
                }
            }

            if(items.Count == counter)
            {
                result = "";
            }
            result += '\n';
            return result;
        }
    }

    internal bool HasItem(Item neededItem)
    {
        foreach (Item item in items)
        {
            if (neededItem == item && item.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach(Connection connection in connections)
        {
            if (connection.connectionEnabled)
            {
                result += connection.description + "\n";
            }
        }

        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if(connection.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return connection;
            }
        }

        return null; 
    }
}
