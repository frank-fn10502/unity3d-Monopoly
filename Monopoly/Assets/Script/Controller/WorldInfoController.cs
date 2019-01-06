using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInfoController : MonoBehaviour
{
    private GameObject panel;
    private bool show;
    private void Start()
    {
        panel = GameObject.Find("WorldMsg");
        show = false;
    }

    public void onBurttonClick()
    {
        panel.SetActive(show);
        show = !show;
    }
}
