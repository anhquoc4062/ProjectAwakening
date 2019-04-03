using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager: MonoBehaviour
{
    public static Dictionary<string, bool> isPickuped { get; set; }
    public static Dictionary<string, bool> isSolved { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        isPickuped = new Dictionary<string, bool>();
        isPickuped["crowbar"] = false;
        isPickuped["key"] = false;
        isPickuped["hammer"] = false;
        isPickuped["bandage"] = false;
        isPickuped["flashlight"] = false;

        isSolved = new Dictionary<string, bool>();
        isSolved["key_puzzle"] = false;
        isSolved["crowbar_puzzle"] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
