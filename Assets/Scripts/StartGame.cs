using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartCombat()
    {
        PlayerStats.instance.selectedSpells = SpellManager.instance.selectedSpells;

        SceneManager.LoadScene("CombatTest" +
            "");
    }
}
