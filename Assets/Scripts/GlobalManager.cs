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
    public static bool firstGoToToilet { get; set; }
    // Start is called before the first frame update

    static GlobalManager()
    {
        playerPosition = 0;
        countDollBurned = 0;
        countSquired = 0;
        firstGoToToilet = true;

        isPickuped = new Dictionary<string, bool>();

        isPickuped["keywhite"] = false;
        isPickuped["keyred"] = false;
        isPickuped["keyyellow"] = false;

        isPickuped["bandage01"] = false;
        isPickuped["bandage02"] = false;
        isPickuped["bandage03"] = false;
        isPickuped["bandage04"] = false;
        isPickuped["bandage05"] = false;
        isPickuped["bandage06"] = false;
        isPickuped["bandage07"] = false;
        isPickuped["bandage08"] = false;

        isPickuped["flashlight"] = false;

        isPickuped["doll01"] = false;
        isPickuped["doll02"] = true;
        isPickuped["doll03"] = true;
        isPickuped["doll04"] = true;
        isPickuped["doll05"] = true;

        isPickuped["match"] = false;
        isPickuped["umbrella"] = false;
        isPickuped["cutter"] = false;
        isPickuped["crowbar"] = false;
        isPickuped["hammer"] = false;

        isSolved = new Dictionary<string, bool>();

        isSolved["keywhite_puzzle"] = false;
        isSolved["keyred_puzzle"] = false;
        isSolved["keyyellow_puzzle"] = false;

        isSolved["crowbar_puzzle"] = false;
        isSolved["fire_puzzle"] = false;
        isSolved["fan_puzzle"] = false;
        isSolved["stair_puzzle"] = false;
        isSolved["hammer_puzzle"] = false;

        isSolved["doll01_puzzle"] = false;
        isSolved["doll02_puzzle"] = false;
        isSolved["doll03_puzzle"] = false;
        isSolved["doll04_puzzle"] = false;
        isSolved["doll05_puzzle"] = false;
    }
}
