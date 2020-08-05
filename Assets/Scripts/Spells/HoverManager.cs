using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoverManager : MonoBehaviour
{
    public Text nameText;
    public Text damageText;
    public Text castTimeText;
    public Text descriptionText;
    public Text typeText;
    public Image icon;

    #region Singleton
    public static HoverManager instance;
    private bool gameStart = false;
    private void Awake()
    {
        if (!gameStart)
        {

            //Check if we are making the instance in the awake function
            if (instance != null)
            {
                Debug.LogWarning("A pre-existing instance of hover manager has been found.");
                return;
            }
            instance = this;

            gameStart = true;
        }
    }

    #endregion

    public void DisplaySpell(Spell spell)
    {
        nameText.text = spell.Name;
        damageText.text = "Damage: " + spell.Damage;
        castTimeText.text = "Cast Time: " + spell.CastTime;
        descriptionText.text = "Description: " + spell.Description;
        typeText.text = "Type: " + spell.Type.ToString();

        icon.sprite = spell.Icon;
    }
}
