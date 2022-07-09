using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/HasTalkedToNPC", order = 5)]
public class HasTalkedToNPC_ScriptableObject: ScriptableObject
{
    //[Header("READ_ONLY or ticked for quick test")]

    [Header("Has which Item?")]
    [SerializeField]
    private bool hasHamantash;

    public bool HasHamantash
    {
        get
        {
            return hasHamantash;
        }
        set
        {
            hasHamantash = value;
        }
    }

    [SerializeField]
    private bool hasFlour;

    public bool HasFlour
    {
        get
        {
            return hasFlour;
        }
        set
        {
            hasFlour = value;
        }
    }

    [SerializeField]
    private bool hasEgg;

    public bool HasEgg
    {
        get
        {
            return hasEgg;
        }
        set
        {
            hasEgg = value;
        }
    }

    [SerializeField]
    private bool hasOil;

    public bool HasOil
    {
        get
        {
            return hasOil;
        }
        set
        {
            hasOil = value;
        }
    }

    [Header("Has talked to which NPC")]
    [Tooltip("Caroline the Rabbit")]
    [SerializeField]
    private bool hasTalkedTo_NPC_Rabbit;

    public bool HasTalkedTo_NPC_Rabbi
    {
        get
        {
            return hasTalkedTo_NPC_Rabbit;
        }
        set
        {
            hasTalkedTo_NPC_Rabbit = value;
        }
    }

    [Tooltip("Malka the Grandma")]
    [SerializeField]
    private bool hasTalkedTo_NPC_Grandma;

    public bool HasTalkedTo_NPC_Grandma
    {
        get
        {
            return hasTalkedTo_NPC_Grandma;
        }
        set
        {
            hasTalkedTo_NPC_Grandma = value;
        }
    }

    [Tooltip("Amon the Grandpa")]
    [SerializeField]
    private bool hasTalkedTo_NPC_Grandpa;

    public bool HasTalkedTo_NPC_Grandpa
    {
        get
        {
            return hasTalkedTo_NPC_Grandpa;
        }
        set
        {
            hasTalkedTo_NPC_Grandpa = value;
        }
    }

    [Tooltip("Tom the Wolf")]
    [SerializeField]
    private bool hasTalkedTo_NPC_Wolf;

    public bool HasTalkedTo_NPC_Wolf
    {
        get
        {
            return hasTalkedTo_NPC_Wolf;
        }
        set
        {
            hasTalkedTo_NPC_Wolf = value;
        }
    }

    [Tooltip("a the Bird")]
    [SerializeField]
    private bool hasTalkedTo_NPC_Bird;

    public bool HasTalkedTo_NPC_Bird
    {
        get
        {
            return hasTalkedTo_NPC_Bird;
        }
        set
        {
            hasTalkedTo_NPC_Bird = value;
        }
    }

    [Tooltip("b the Squirrel")]
    [SerializeField]
    private bool hasTalkedTo_NPC_Squirrel;

    public bool HasTalkedTo_NPC_Squirrel
    {
        get
        {
            return hasTalkedTo_NPC_Squirrel;
        }
        set
        {
            hasTalkedTo_NPC_Squirrel = value;
        }
    }

    [Header("Is Door to this NPC unlocked?")]
    [SerializeField]
    private bool hasUnlockedDoor_NPC_Grandparents;

    public bool HasUnlockedDoor_NPC_Grandparents
    {
        get
        {
            return hasUnlockedDoor_NPC_Grandparents;
        }
        set
        {
            hasUnlockedDoor_NPC_Grandparents = value;
        }
    }

    [SerializeField]
    private bool hasUnlockedDoor_ToHallway;

    public bool HasUnlockedDoor_ToHallway
    {
        get
        {
            return hasUnlockedDoor_ToHallway;
        }
        set
        {
            hasUnlockedDoor_ToHallway = value;
        }
    }

    [SerializeField]
    private bool hasUnlockedDoor_NPC_Wolf;

    public bool HasUnlockedDoor_NPC_Wolf
    {
        get
        {
            return hasUnlockedDoor_NPC_Wolf;
        }
        set
        {
            hasUnlockedDoor_NPC_Wolf = value;
        }
    }

    [SerializeField]
    private bool hasUnlockedDoor_NPC_Bird;

    public bool HasUnlockedDoor_NPC_Bird
    {
        get
        {
            return hasUnlockedDoor_NPC_Bird;
        }
        set
        {
            hasUnlockedDoor_NPC_Bird = value;
        }
    }

    [SerializeField]
    private bool hasUnlockedDoor_NPC_Squirrel;
    internal bool HasUnlockedDoor_ToMyRoom;

    public bool HasUnlockedDoor_NPC_Squirrel
    {
        get
        {
            return hasUnlockedDoor_NPC_Squirrel;
        }
        set
        {
            hasUnlockedDoor_NPC_Squirrel = value;
        }
    }

    public void ResetAllHasTalkedToFalse()
    {
        hasTalkedTo_NPC_Rabbit = false;
        hasTalkedTo_NPC_Grandma = false;
        hasTalkedTo_NPC_Grandpa = false;
        hasTalkedTo_NPC_Wolf = false;
        hasTalkedTo_NPC_Bird = false;
        hasTalkedTo_NPC_Squirrel = false;
    }

    public void ResetAllUnlockedDoorToFalse()
    {
        hasUnlockedDoor_ToHallway = false;
        hasUnlockedDoor_NPC_Wolf = false;
        hasUnlockedDoor_NPC_Bird = false;
        hasUnlockedDoor_NPC_Squirrel = false;
    }

}