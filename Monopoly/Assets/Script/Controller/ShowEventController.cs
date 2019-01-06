using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEventController : MonoBehaviour {

    // Use this for initialization
    GameObject obj;
    string[] vs;

    void Start ()
    {
        obj = GameObject.Find("WorldMsgShow/TheWorldMsg");
        string str = obj.GetComponent<Control>().GetText();
        vs = str.Split('\n');
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (string s in vs)
        {
            GameObject.Find("EndMsgShow/TheEndMsg").GetComponent<Control>().WriteText(s);
        }
	}
}
