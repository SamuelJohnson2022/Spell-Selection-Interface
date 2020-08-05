using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats:MonoBehaviour
{

    #region Singleton
    //Inventory.instance is used to access this object
    public static PlayerStats instance;

    private bool gameStart;

    private void Awake()
    {
        if (!gameStart)
        {

            //Check if we are making the instance in the awake function
            if (instance != null)
            {
                Debug.LogWarning("A pre-existing instance of player stats has been found.");
            }
            instance = this;

            DontDestroyOnLoad(gameObject);
            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            gameStart = true;
        }
    }

    #endregion

    public List<Spell> selectedSpells = new List<Spell>();

    int money = 0;

}
