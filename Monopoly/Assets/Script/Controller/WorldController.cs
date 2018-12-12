using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public World world;
    //public Camera characterCamera;
    void Start()
    {
        world = new World();
        //gameObject.transform.position = world.CurrentGroup.Location + new Vector3(0 ,4 ,-4);
    }
    void Update()
    {
        world.execute();
        gameObject.transform.position = world.CurrentGroup.Location + new Vector3(5 ,13 ,-6);
    }
}
