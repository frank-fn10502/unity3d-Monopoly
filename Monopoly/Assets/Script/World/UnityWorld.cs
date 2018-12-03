using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityWorld : MonoBehaviour
{
    public World world;
    Camera characterCamera;
    // Use this for initialization
    void Start()
    {
        world = new World();
        world.map.build();
        characterCamera = GameObject.Find("CharacterCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        world.playerAction();
        characterCamera.transform.position = world.CurrentGroup.Location + new Vector3(0 ,4 ,-4);
    }
}
