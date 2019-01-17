using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEventController : MonoBehaviour {

    // Use this for initialization
    GameObject obj;
    string[] vs;
    int index;
    int timer;
    bool isEnd;

    void Start ()
    {
        isEnd = false;
        index = 0;
        timer = 0;
        obj = GameObject.Find("WorldMsgShow/TheWorldMsg");
        string str = obj.GetComponent<Control>().GetText();
        vs = str.Split('\n');
        GameObject.Destroy(GameObject.Find("Canvas"));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timer % 3 == 0 && !isEnd)
        {
            GameObject.Find("EndMsgShow/TheEndMsg").GetComponent<Control>().WriteText(vs[index++]+ "\n");
            if (vs.Length -1 == index)
            {
                isEnd = true;
                
            }
            timer = 0;
       }
       timer++;
    }
}
