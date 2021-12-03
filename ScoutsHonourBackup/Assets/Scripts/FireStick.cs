using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStick : MonoBehaviour
{
    Vector3 mOffset;
    float mZCoord;

    public Rigidbody stickRB;

    public GameManager GM;
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;

        if (stickRB.velocity.y *10e14 > 4 || stickRB.velocity.y *10e14 < -4)
        {
            GM.fireStarted = true;
            GM.ObjectivesCompleted(3);
            GM.fireBadge.SetActive(true);
            GM.noFireBadge.SetActive(false);
            GM.fireEndBadge.SetActive(true);
            GM.fireBadgeAchievement.SetActive(true);
        }
        Debug.Log(stickRB.velocity.y * 10e6);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
