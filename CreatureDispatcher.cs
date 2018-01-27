[System.Serializable]
public class MonsterStats
{
    // ==================================================================
    //                          CREATURE STATS DATABASE JSON
    // ==================================================================
    public string name;
    public bool isBoss = false;
    public bool canFly = false;
    public Immunity immunity;
    public Level[] level; // cause it has to match the json file. that's why it's cap. 
}

[System.Serializable]
public class Level
{
    public int level; // Level is an int do not use 0 in front of any digit it will break the database. 
    public Normal normal;
    public Elite elite;
}

[System.Serializable]
public class Normal
{
    public int health;
    public int move;
    public int attack;
    public int range;

    [Header("Conditions")]
    public bool poison = false;
    public bool muddle = false;
    public bool curse = false;
    public bool immobolize = false;
    public bool disarm = false;
    public bool wound = false;
    public bool stun = false;
    public bool advantage = false;
    public bool disadvantage = false;

    [Header("Pierce Settings")]
    public int pierce = 0;

    [Header("Shield Settings")]
    public int shield = 0;

    [Header("Multiple Targets Settings")]
    public int target = 0;

    [Header("Retaliate Settings")]
    public int retaliate = 0;
    public int retaliateRange = 0;
}

[System.Serializable]
public class Immunity
{
    [Header("Conditions")]
    public bool poison = false;
    public bool muddle = false;
    public bool curse = false;
    public bool immobolize = false;
    public bool disarm = false;
    public bool wound = false;
    public bool stun = false;
    public bool advantage = false;
    public bool disadvantage = false;
    public bool push = false;
    public bool pull = false;    
}

[System.Serializable]
public class Elite
{
    public int health;
    public int move;
    public int attack;
    public int range;

    [Header("Conditions")]
    public bool poison = false;
    public bool muddle = false;
    public bool curse = false;
    public bool immobolize = false;
    public bool disarm = false;
    public bool wound = false;
    public bool stun = false;
    public bool advantage = false;
    public bool disadvantage = false;

    [Header("Pierce Settings")]
    public int pierce = 0;

    [Header("Shield Settings")]
    public int shield = 0;

    [Header("Multiple Targets Settings")]
    public int target = 0;

    [Header("Retaliate Settings")]
    public int retaliate = 0;
    public int retaliateRange = 0;
}



// ==================================================================
//                          DECK DATABASE JSON
// ==================================================================

[System.Serializable]
public class Deck
{
    public string name;
    public Cards[] cards;
}

[System.Serializable]
public class Cards
{
    public bool shuffle;
    public int initiative;
    public Line[] line; // This will eventually be changed to the "class Line"
}

[System.Serializable]
public class Line
{
    public string name;
    // Types: attack, move, heal, retaliate, push, pull, createElement, convert element, umm might be more
  
    public bool jump = false;
    // integers
    public int mod = 0;
    public int range = 0;
    // For Heal the range would be set to 0 for (self)
    public int shield = 0;
    public int pierce = 0;
    public int push = 0;
    public int pull = 0;
    // Strings
    public string aoe = "";   // just reference the other db for now. 
    public string label = ""; // This is the text tha appears on a line
    // Conditions
    public bool immobilize = false;
    public bool curse = false;
    public bool wound = false;
    public bool disarm = false;
    public bool muddle = false;
    public bool poison = false;
    public bool stun = false;
    public bool bless = false;
}

