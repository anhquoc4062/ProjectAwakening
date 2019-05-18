using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalManager
{
    public static Dictionary<string, bool> isPickuped { get; set; }
    public static Dictionary<string, bool> isSolved { get; set; }

    public static float playerPosition { get; set; }
    public static int countDollBurned { get; set; }
    public static int countSquired { get; set; }
    // Start is called before the first frame update

    static GlobalManager()
    {
        playerPosition = 0;
        countDollBurned = 0;
        countSquired = 0;

        isPickuped = new Dictionary<string, bool>();
        isPickuped["crowbar"] = false;
        isPickuped["key"] = false;
        isPickuped["hammer"] = false;
        isPickuped["bandage"] = false;
        isPickuped["flashlight"] = false;
        isPickuped["doll01"] = false;
        isPickuped["doll02"] = true;
        isPickuped["doll03"] = true;
        isPickuped["doll04"] = true;
        isPickuped["doll05"] = true;
        isPickuped["match"] = false;

        isSolved = new Dictionary<string, bool>();
        isSolved["key_puzzle"] = false;
        isSolved["crowbar_puzzle"] = false;
        isSolved["fire_puzzle"] = false;

        isSolved["doll01_puzzle"] = false;
        isSolved["doll02_puzzle"] = false;
        isSolved["doll03_puzzle"] = false;
        isSolved["doll04_puzzle"] = false;
        isSolved["doll05_puzzle"] = false;
    }
}
