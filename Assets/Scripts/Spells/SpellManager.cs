using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    #region Singleton
    //Inventory.instance is used to access this object
    public static SpellManager instance;

    private bool gameStart;

    private void Awake()
    {
        if (!gameStart)
        {

            //Check if we are making the instance in the awake function
            if (instance != null)
            {
                Debug.LogWarning("A pre-existing instance of spell select has been found.");
            }
            instance = this;

            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            gameStart = true;
        }
    }

    #endregion

    //Delegate to signify inventory is changed
    public delegate void OnSpellChanged();
    public OnSpellChanged onSpellChangedCallback;

    public int space = 33;
    public int numSelected = 0;

    public GameObject[] activeSpellPanels;
    public Text[] nameText;
    public Text[] damageText;
    public Text[] castTimeText;
    public Text[] descriptionText;
    public Text[] typeText;
    public Image[] icon;

    public List<Spell> selectedSpells = new List<Spell>();

    public List<Spell> spells = new List<Spell>();

    public bool HightlightSpell(bool wasSelected, Spell spell)
    {
        if(wasSelected)
        {
            numSelected -= 1;
            selectedSpells.Remove(spell);
            DisplayActiveSpells();
            return true;
        } else
        {
            if(numSelected >= 4)
            {
                return false;
            }
            else
            {
                numSelected += 1;
                selectedSpells.Add(spell);
                DisplayActiveSpells();
                return true;
            }
        }
    }

    //Loops through the list of selected spells and enables the game objects for their displays
    public void DisplayActiveSpells()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i < selectedSpells.Count && selectedSpells[i] != null)
            {
                //Sets all of the data for the selected spell
                nameText[i].text = selectedSpells[i].name;
                damageText[i].text = "Damage: " + selectedSpells[i].Damage;
                castTimeText[i].text = "Cast Time: " + selectedSpells[i].CastTime;
                descriptionText[i].text = "Description: " + selectedSpells[i].Description;
                typeText[i].text = "Type: " + selectedSpells[i].Type;
                icon[i].sprite = selectedSpells[i].Icon;

                //Activates the spell display window
                activeSpellPanels[i].SetActive(true);
            }
            else
            {
                activeSpellPanels[i].SetActive(false);
            }
        }
    }

}
