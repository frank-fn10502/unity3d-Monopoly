using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityWorld : MonoBehaviour
{
    World world;
    // Use this for initialization
    void Start ()
    {
        world = new World();
        world.map.build();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        world.playerAction();
        */
	}
}
