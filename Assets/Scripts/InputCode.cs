using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCode : MonoBehaviour
{
    public InputField inputField;
    public string correctString;
    // Start is called before the first frame update
    void Start()
    {
        inputField = gameObject.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputAlpha (int alpha)
    {
        inputField.text += alpha.ToString();
    }

    public void InputDel()
    {
        int len = inputField.text.Length;
        string text = inputField.text;

        inputField.text = text.Substring(0,len-1);
    }

    public void InputSubmit()
    {
        Text text = inputField.transform.Find("Text").GetComponent<Text>();
        if (inputField.text == correctString)
        {
            //do something
            text.color = Color.green;
        }
        else
        {
            
            text.color = Color.red;
            StartCoroutine(WaitToRemove(1f));
        }
    }

    IEnumerator WaitToRemove(float sec)
    {
        yield return new WaitForSeconds(sec);
        inputField.text = "";
    }
}
