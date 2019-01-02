using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Use this for initialization
    public void OnStartGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
