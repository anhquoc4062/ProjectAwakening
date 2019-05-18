using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalManager
{
    public static Dictionary<string, bool> isPickuped { get; set; }
    public static Dictionary<string, bool> isSolved { get; set; }

    public static float playerPosition { get; set; }
    // Start is called before the first frame update

    static GlobalManager()
    {
        playerPosition = 0;

        isPickuped = new Dictionary<string, bool>();
        isPickuped["crowbar"] = false;
        isPickuped["key"] = false;
        isPickuped["hammer"] = false;
        isPickuped["bandage"] = false;
        isPickuped["flashlight"] = false;
        isPickuped["doll01"] = false;
        isPickuped["doll02"] = false;
        isPickuped["doll03"] = false;
        isPickuped["doll04"] = false;
        isPickuped["doll05"] = false;
        isPickuped["match"] = false;

        isSolved = new Dictionary<string, bool>();
        isSolved["key_puzzle"] = false;
        isSolved["crowbar_puzzle"] = false;
        isSolved["fire_puzzle"] = false;
    }
}
