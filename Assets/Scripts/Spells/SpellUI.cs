using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellUI : MonoBehaviour
{
    public Transform spellsParent;

    SpellManager spellManager;
    public GameObject spellUI;


    SpellSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        spellManager = SpellManager.instance;
        spellManager.onSpellChangedCallback += UpdateUI;

        slots = spellsParent.GetComponentsInChildren<SpellSlot>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Spells"))
        {
            spellUI.SetActive(!spellUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        //Displaying all spells
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < spellManager.spells.Count)
            {
                slots[i].DisplaySpell(spellManager.spells[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
