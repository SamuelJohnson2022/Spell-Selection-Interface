using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    public Image icon;
    public int spellSlotNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.instance == null)
        {
            Debug.LogWarning("Missing PlayerStats instance.");
            return;
        }
        if(PlayerStats.instance.selectedSpells[spellSlotNumber] != null)
        {
            icon.sprite = PlayerStats.instance.selectedSpells[spellSlotNumber].Icon;
        } 
        else
        {
            icon.sprite = null;
        }
        
    }
}
