using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Text textView;
    [SerializeField]
    private ScrollRect scrollControl;
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void WriteText(string text)
    {
        textView.text += text;
        StartCoroutine("ScrollToBottom");
    }

    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        scrollControl.verticalNormalizedPosition = 0f;
    }
    public string GetText()
    {
        return textView.text;
    }
}
