using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CheckOut(int no);
public delegate void Select(int no);
public class PositionController : MonoBehaviour
{
    public int pathNo;
    private CheckOut checkOut;
    private Select select;

    public CheckOut CheckOut
    {
        set { checkOut = value; }
    }
    public Select Select
    {
        set { select = value; }
    }

    void OnMouseDown()
    {
        checkOut(pathNo);
    }
    private void OnMouseEnter()
    {
        select(pathNo);
    }
}
