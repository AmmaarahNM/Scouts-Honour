using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialManager : MonoBehaviour
{
    public GameObject layer1;
    bool layer1Active;

    public GameObject layer2;
    bool layer2Active;

    public GameObject layer3;
    bool layer3Active;               //PUT IN AN ARRAY

    //public Rigidbody vialRB;
    public bool thisOneRaised;

    public GameManager GM;
    public PurifierManager PuM;
    private void OnMouseDown()
    {
        if (PuM.oneRaised)
        {
            if (thisOneRaised)
            {
                thisOneRaised = false;
            }

            else
            {
                //new layer activates
                //deactivate highest layer one raised one
            }
        }

        else
        {
            PuM.oneRaised = true;
            thisOneRaised = true;
            PuM.raisedOne = gameObject;
        }
    }
   

    
}
