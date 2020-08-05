using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Character/Spells")]
public class Spell : ScriptableObject
{
    [SerializeField] new string name = "New Spell";

    [TextArea]
    [SerializeField] string description = "Default Description";

    [SerializeField] Sprite icon = null;
    //[SerializeField] Animation Animation;

    [SerializeField] SpellType type = SpellType.None;
    [SerializeField] HarmfulStatusEffect enemyInflictedStatus = HarmfulStatusEffect.None;
    [SerializeField] HelpfulStatusEffect selfInflictedStatus = HelpfulStatusEffect.None;

    // Base Stats
    [SerializeField] int damage = 0; //0-1000
    [SerializeField] int castTime = 0; //0-500 (100 per turn)

    #region Properties
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }

    public SpellType Type
    {
        get { return type; }
    }

    public HarmfulStatusEffect EnemyInflictedStatus
    {
        get { return enemyInflictedStatus; }
    }

    public HelpfulStatusEffect SelfInflictedStatus
    {
        get { return selfInflictedStatus; }
    }

    public int Damage
    {
        get { return damage; }
    }

    public int CastTime
    {
        get { return castTime; }
    }

    #endregion

}

//Finish this later
public enum SpellType
{
    None,
    Fire,
    Lightning,
    Water,
    Air,
    Ice,
    Illusion,
    Undead,
    Nature,
    Void,
    Lullaby,
    Holy,
    Intellectual,
    Toxic

}

public enum HarmfulStatusEffect
{
    None,
    Ignite, //% of initial damage over time
    Hypothermia, //Slowed (Speed Decreased)
    Shocked, //% Increased damage taken
    Poisoned, //% Decreased stats (HP, Damage?)
    Terrified, //Disabled for x turns
    Disoriented,
    Silenced,
    Asleep,
    Linked,
    Rooted

}

public enum HelpfulStatusEffect
{
    None,
    Empowered, //Increases damage of next spell
    Hastened, //Reduced Cast time of next spell
    Regeneration, //Heals amount over 3 turns
    Reinforced //Takes less damage from next spell

}
