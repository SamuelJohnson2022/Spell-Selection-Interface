using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Image icon;
    public Button selectButton;
    public Image outline;
    public bool isSelected;

    public GameObject HoverWindow;    

    Spell spell;

    public void DisplaySpell(Spell newSpell)
    {
        spell = newSpell;

        icon.sprite = spell.Icon;
        icon.enabled = true;
        selectButton.interactable = true;
        isSelected = false;

    }

    public void ClearSlot()
    {
        spell = null;

        icon.sprite = null;
        icon.enabled = false;
        selectButton.interactable = false;
        outline.enabled = false;
        isSelected = false;
    }

    public void onSelectButton()
    {
        //Checks if there are alread 4 highlighted spells
        if(SpellManager.instance.HightlightSpell(isSelected, spell))
        {
            outline.enabled = !isSelected;
            isSelected = !isSelected;
        }
    }

    public void OnHover()
    {
        HoverWindow.SetActive(true);
        HoverManager.instance.DisplaySpell(spell);
    }

    public void OffHover()
    {
        HoverWindow.SetActive(false);
    }
}
