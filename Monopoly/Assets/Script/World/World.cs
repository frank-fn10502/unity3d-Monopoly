using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class World : MonoBehaviour
{
    Map map;

    // Use this for initialization
    void Start()
    {
        string json = File.ReadAllText(@"C:\Users\kevin\Documents\unity3d-Monopoly\Monopoly\Assets\Resources\Texture\map.xsa");
        map = JsonConvert.DeserializeObject<Map>(json);
        
        map.build();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
