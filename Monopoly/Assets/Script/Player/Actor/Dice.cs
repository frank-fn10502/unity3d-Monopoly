using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    private int[] face;
    private GameObject entity;

    public Dice(int[] face)
    {
        this.face = face;
    }

    public int[] Face
    {
        get
        {
            return face;
        }
    }
}
