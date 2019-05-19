using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountBurnedPuppet : MonoBehaviour
{
    public TextMeshProUGUI textCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCount.text = GlobalManager.countDollBurned.ToString() + "/5";
    }
}
