using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifierManager : MonoBehaviour
{
    //public bool oneRaised;
    //public GameObject raisedOne;

    bool oneRaised;
    bool twoRaised;
    bool threeRaised;

    public Material blue;
    public Material brown;
    public Material green;

    public MeshRenderer[] vialOne;
    public MeshRenderer[] vialTwo;
    public MeshRenderer[] vialThree;

    public GameManager GM;

    bool vialOneReady;
    bool vialTwoReady;
    bool vialThreeReady;

    // Start is called before the first frame update
    void Start()
    {
        if (!GM.purified)
        {
            vialOne[2].enabled = false;
            vialOne[1].material = brown;
            vialOne[0].material = green;

            vialTwo[2].enabled = false;
            vialTwo[1].material = brown;
            vialTwo[0].material = blue;

            vialThree[2].enabled = false;
            vialThree[1].material = green;
            vialThree[0].material = blue;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vialOne[0].material == vialOne[1].material && vialOne[2].enabled == false)
        {
            vialOneReady = true;
        }

        else
        {
            vialOneReady = false;
        }

        if (vialTwo[0].material == vialTwo[1].material && vialTwo[2].enabled == false)
        {
            vialTwoReady = true;
        }

        else
        {
            vialTwoReady = false;
        }

        if (vialThree[0].material == vialThree[1].material && vialThree[2].enabled == false)
        {
            vialThreeReady = true;
        }

        else
        {
            vialThreeReady = false;
        }

        if (vialOneReady && vialTwoReady && vialThreeReady)
        {
            GM.WaterPurified();
        }

        if (!oneRaised && !twoRaised && !threeRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                oneRaised = true;
                //VIAL ONE UP ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                twoRaised = true;
                //VIAL TWO UP ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                threeRaised = true;
                //VIAL THREE UP ANIMATION
            }


        }

        if (oneRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                oneRaised = false;
                //VIAL ONE DOWN ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OneToTwo();
                //ONE OVER TWO ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OneToThree();
                //ONE OVER THREE ANIMATION
            }
        }

        if (twoRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TwoToOne();
                //TWO OVER ONE ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                twoRaised = false;
                //VIAL TWO DOWN ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TwoToThree();
                //TWO OVER THREE ANIMATION
            }
        }

        if (threeRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ThreeToOne();
                //THREE OVER ONE ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ThreeToTwo();
                //THREE OVER TWO ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                threeRaised = false;
                //VIAL THREE DOWN ANIMATION
            }
        }
    }

    public void OneToTwo()
    {
        if (vialTwo[0].enabled && vialTwo[1].enabled && vialTwo[2].enabled)
        {
            Debug.Log("vial 2 full!");
        }

        else if (!vialTwo[1].enabled)
        {
            if (vialOne[2].enabled)
            {
                vialTwo[1].material = vialOne[2].material;
                vialTwo[1].enabled = true;
                vialOne[2].enabled = false;
            }

            else if (vialOne[1].enabled)
            {
                vialTwo[1].material = vialOne[1].material;
                vialTwo[1].enabled = true;
                vialOne[1].enabled = false;
            }

            else if (vialOne[0].enabled)
            {
                vialTwo[1].material = vialOne[0].material;
                vialTwo[1].enabled = true;
                vialOne[0].enabled = false;
            }

            else
            {
                Debug.Log("vial 1 empty!");
            }
             

        }
    }

    public void OneToThree()
    {

    }

    public void TwoToOne()
    {

    }

    public void TwoToThree()
    {

    }

    public void ThreeToOne()
    {

    }

    public void ThreeToTwo()
    {

    }
}
