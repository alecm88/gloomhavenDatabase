using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreatureDispatcher : MonoBehaviour {
    // String variable that's going to hold our file. 
    string path;

    // Hold the raw json data
    string jsonString;

    public CreatureList[] creatureList;
    public GameObject[] cardList;
    public List<MonsterStats> creatures;
    DeckDB deckDB;


    private void Start()
    {

        // Path to json File and we want the path to a certain file. 
        path = Application.streamingAssetsPath + "/Deck.json";
        // Now we want to bring it into Unity. 
        jsonString = File.ReadAllText(path);

        // FromJson - We pass it the creature type so the from json it knows what to map it to. 
        // Creature test - so it knows what it's working with (db)
        deckDB = JsonUtility.FromJson<DeckDB>(jsonString);

        // THEN REPEAT

        for (int i = 0; i < creatureList.Length; i++)
        {
            // Path to json File and we want the path to a certain file. 
            path = Application.streamingAssetsPath + creatureList[i].dbStatPath;
            // Now we want to bring it into Unity. 
            jsonString = File.ReadAllText(path);

            // FromJson - We pass it the creature type so the from json it knows what to map it to. 
            // Creature test - so it knows what it's working with (db)
            MonsterStats mStat = JsonUtility.FromJson<MonsterStats>(jsonString);
            creatureList[i].stats = mStat;

            foreach (Deck deck in deckDB.deck)
            {
                if(deck.name == creatureList[i].DeckType)
                {
                    creatureList[i].deck = deck;
                }
            }
        }

        ResetAllMonsters();

    }

    public void ResetAllMonsters()
    {
        for (int i = 0; i < creatureList.Length; i++)
        {
            foreach (Creature creature in creatureList[i].creature)
            {
                creature.status = Creature.Status.Dead;
            }
            creatureList[i].shuffleDeck();
            
        }
    }
}
// We have to tell unity that this IS serializable.
[System.Serializable]
public class MonsterStats
{
    public string name;
    public bool isBoss = false;
    public bool canFly = false;
    public Immunity immunity;
    public Level[] level; // cause it has to match the json file. that's why it's cap. 
}

[System.Serializable]
public class Level
{
    public int level;
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

// We have to tell unity that this IS serializable.
[System.Serializable]
public class DeckDB
{
    public Deck[] deck;
}

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
    /* Types:
     * attack, move, heal, retaliate, push, pull, createElement, convert element
     */
    public bool jump = false;
    // integers
    public int mod = 0;
    public int range = 0;
    public int shield = 0;
    public int pierce = 0;
    public int push = 0;
    public int pull = 0;
    // Strings
    public string aoe = "";
    public string label = "";
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

