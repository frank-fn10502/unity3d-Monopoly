using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMsgController : MonoBehaviour
{
    public void showButtonClick()
    {
        gameObject.SetActive(true);
    }
    public void hideButtonClick()
    {
        gameObject.SetActive(false);
    }
}
