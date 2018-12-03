using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPath : MonoBehaviour
{
    public int pathNo;
    public Scout scout;

    void OnMouseDown()
    {
        scout.checkOutPath(pathNo);
    }
    private void OnMouseEnter()
    {
        scout.selectPath(pathNo);
    }
}
