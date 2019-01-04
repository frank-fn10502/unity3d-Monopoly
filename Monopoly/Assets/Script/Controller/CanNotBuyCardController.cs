using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanNotBuyCardController : MonoBehaviour
{
    public void checkoutButtonClick()
    {
        gameObject.SetActive(false);
    }
}
