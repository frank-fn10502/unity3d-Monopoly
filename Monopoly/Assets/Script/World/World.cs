using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    Map map;
    // Use this for initialization
    void Start ()
    {
        map = new Map();
        map.build();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
