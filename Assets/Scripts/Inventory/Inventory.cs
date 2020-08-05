using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    //Inventory.instance is used to access this object
    public static Inventory instance;

    private void Awake()
    {
        //Check if we are making the instance in the awake function
        if(instance != null)
        {
            Debug.LogWarning("A pre-existing instance of inventory has been found.");
        }
        instance = this;
    }

    #endregion

    //Delegate to signify inventory is changed
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();
    
    //Used to add an item into the inventory
    //Returns true if the item is added successfully, false if not
    public bool Add(Item item)
    {
        //Check to see if there is space in the inventory
        if(items.Count >= space)
        {
            Debug.Log("Your inventory is full.");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public bool Remove(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);

            if (onItemChangedCallback != null )
                onItemChangedCallback.Invoke();
            
            return true;
        } else
        {
            Debug.Log(item.name + " was not found in Inventory.");
            return false;
        }
        
    }
}
