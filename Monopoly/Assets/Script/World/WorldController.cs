using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//public delegate void PlayerAction();

public class WorldController : MonoBehaviour
{
    public World world;
    public Camera characterCamera;
    void Start()
    {
        world = new World();
        //world.map.build();
        //characterCamera = GameObject.Find("CharacterCamera").GetComponent<Camera>();
    }
    void Update()
    {
        world.execute();//.playerAction();
        characterCamera.transform.position = world.CurrentGroup.Location + new Vector3(0 ,4 ,-4);
    }
}
