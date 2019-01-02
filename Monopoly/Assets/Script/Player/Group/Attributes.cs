using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
    public int leadership;
    public int diplomatic;
    public int peace;

    public Attributes()
    {

    }
    public Attributes(int leadership ,int diplomatic ,int peace)
    {
        this.leadership = leadership;
        this.diplomatic = diplomatic;
        this.peace = peace;
    }
    public Attributes(Attributes another)
    {
        leadership = another.leadership;
        diplomatic = another.diplomatic;
        peace = another.peace;
    }
}
