using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdBinocularsRange : MonoBehaviour
{
    
    public Camera cam;
    public GameManager GM;
    public bool isVisible;
    public Renderer rend;
    public GameObject birdJournal;
    bool firstSeen;
    

    private void Start()
    {
        isVisible = false;
    }

    /*bool IsVisible ()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(cam);
        var point = this.gameObject.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) > 0)
            {
                return false;
            }
        }

        return true;
    }*/

    /* private void OnBecameVisible()
     {
         isVisible = true;
     }

     private void OnBecameInvisible()
     {
         isVisible = false;
     }*/



    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
        {
            if (Vector3.Distance(cam.transform.position, gameObject.transform.position) < 20) //MAKE CLOSER?
            {
                isVisible = true;
            }

            else
            {
                isVisible = false;
            }
            
        }

        else
        {
            isVisible = false;
        }
        //first check if zoomed to a certain value
        if (isVisible && GM.binocsActive && GM.cam.fieldOfView <= 30)
        {
            if (!firstSeen)
            {
                Debug.Log(this.gameObject.name + "seen!");
                BirdFound();
                firstSeen = true;
            }
            
        }
    }

    public void BirdFound()
    {
       
        GM.newPlantInfo.SetActive(true);
        GM.birdName.text = "Oh wow! You've spotted a " + gameObject.name;
        GM.newBirdInfo.SetActive(true);
        GM.birdsFound++;
        birdJournal.SetActive(true);
        
        if (GM.birdsFound >= 4)
        {
            GM.birdBadge.SetActive(true);
            GM.birdEndBadge.SetActive(true);
            GM.noBirdBadge.SetActive(false);
            GM.birdBadgeAchievement.SetActive(true);
        }

        StartCoroutine(DeactivateNewInfo());
    }

    IEnumerator DeactivateNewInfo()
    {
        yield return new WaitForSeconds(4);
        GM.newBirdInfo.SetActive(false);
        GM.newPlantInfo.SetActive(false);
    }
}
