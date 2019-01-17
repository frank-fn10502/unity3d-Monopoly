using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CheckOut(int no);
public delegate void Select(int no);
public delegate void Leave(int no);
public class PositionController : MonoBehaviour
{
    public int pathNo;
    private CheckOut checkOut;
    private Select select;
    private Leave leave;

    public CheckOut CheckOut
    {
        set { checkOut = value; }
    }
    public Select Select
    {
        set { select = value; }
    }

    public Leave Leave
    {
        set
        {
            leave = value;
        }
    }

    void OnMouseDown()
    {
        checkOut(pathNo);
    }
    private void OnMouseEnter()
    {
        select(pathNo);
    }
    private void OnMouseExit()
    {
        leave(pathNo);
    }
}
