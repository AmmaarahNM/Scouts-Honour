using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeHover : MonoBehaviour
{
    public GameObject info;
    

    private void OnMouseEnter()
    {
        Debug.Log("registers");
        info.SetActive(true);
    }

    private void OnMouseExit()
    {
        info.SetActive(false);
    }
}
