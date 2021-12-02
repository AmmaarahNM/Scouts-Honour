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

    public bool vialOneReady;
    public bool vialTwoReady;
    public bool vialThreeReady;

    public Animator handsAnim;
    public Animator vialAnim;

    public GameObject tubeFull;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("opened");
        if (!GM.purified && GM.waterCollected)
        {
            vialOne[2].enabled = false;
            vialOne[1].enabled = true;
            vialOne[1].material = brown;
            vialOne[0].enabled = true;
            vialOne[0].material = green;

            vialTwo[2].enabled = false;
            vialTwo[1].enabled = true;
            vialTwo[1].material = brown;
            vialTwo[0].enabled = true;
            vialTwo[0].material = blue;

            vialThree[2].enabled = false;
            vialThree[1].enabled = true;
            vialThree[1].material = green;
            vialThree[0].enabled = true;
            vialThree[0].material = blue;
        }

        else
        {
            foreach (MeshRenderer level in vialOne)
            {
                level.enabled = false;
            }

            foreach (MeshRenderer level in vialTwo)
            {
                level.enabled = false;
            }

            foreach (MeshRenderer level in vialThree)
            {
                level.enabled = false;
            }

            //vialOneReady = false;
            //vialTwoReady = false;
            //vialThreeReady = false;
        }
        
    }

    public void StartPurification()
    {
        vialOne[2].enabled = false;
        vialOne[1].enabled = true;
        vialOne[1].material = brown;
        vialOne[0].enabled = true;
        vialOne[0].material = green;

        vialTwo[2].enabled = false;
        vialTwo[1].enabled = true;
        vialTwo[1].material = brown;
        vialTwo[0].enabled = true;
        vialTwo[0].material = blue;

        vialThree[2].enabled = false;
        vialThree[1].enabled = true;
        vialThree[1].material = green;
        vialThree[0].enabled = true;
        vialThree[0].material = blue;

    }
    // Update is called once per frame
    void Update()
    {
        if (vialOne[0].material.color == vialOne[1].material.color && vialOne[0].material != null) // && vialOne[2].enabled == false)
        {
            vialOneReady = true;
        }

        else
        {
            vialOneReady = false;
        }

        if (vialTwo[0].material.color == vialTwo[1].material.color && vialTwo[0].material != null) // && vialTwo[2].enabled == false)
        {
            vialTwoReady = true;
        }

        else
        {
            vialTwoReady = false;
        }

        if (vialThree[0].material.color == vialThree[1].material.color && vialThree[0].material != null) // && vialThree[2].enabled == false)
        {
            vialThreeReady = true;
        }

        else
        {
            vialThreeReady = false;
        }

        /*if ((vialOne[0].material == brown && vialOne[1].material == brown) || (vialOne[0].material == blue && vialOne[1].material == blue) || 
            (vialOne[0].material == green && vialOne[1].material == green))
        {
            vialOneReady = true;
        }

        else
        {
            vialOneReady = false;
        }

        if ((vialTwo[0].material == brown && vialTwo[1].material == brown) || (vialTwo[0].material == blue && vialTwo[1].material == blue) ||
            (vialTwo[0].material == green && vialTwo[1].material == green))
        {
            vialTwoReady = true;
        }
        else
        {
            vialTwoReady = false;
        }

        if ((vialThree[0].material == brown && vialThree[1].material == brown) || (vialThree[0].material == blue && vialThree[1].material == blue) ||
            (vialThree[0].material == green && vialThree[1].material == green))
        {
            vialThreeReady = true;
        }

        else
        {
            vialThreeReady = false;
        }*/

        if (vialOneReady && vialTwoReady && vialThreeReady && GM.waterCollected)
        {
            StartCoroutine(Purified());
            
            
        }

        if (!oneRaised && !twoRaised && !threeRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                oneRaised = true;
                Debug.Log("1 is up");
                handsAnim.Play("HandTestTube3-Up");
                vialAnim.Play("TestTube3-Up");
                //VIAL ONE UP ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                twoRaised = true;
                handsAnim.Play("HandTestTube2-Up");
                vialAnim.Play("TestTube2-Up");
                //VIAL TWO UP ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                threeRaised = true;
                handsAnim.Play("HandTestTube1-Up");
                vialAnim.Play("TestTube1-Up");
                //VIAL THREE UP ANIMATION
            }


        }

        else if (oneRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                oneRaised = false;
                handsAnim.Play("HandTestTube3 -Down");
                vialAnim.Play("TestTube3-Down");
                //VIAL ONE DOWN ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("one to two");
                OneToTwo();
                handsAnim.Play("HandTestTube3-PourTo2");
                vialAnim.Play("TestTube3-PourTo2");
                //ONE OVER TWO ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OneToThree();
                handsAnim.Play("HandTestTube3-PourTo1");
                vialAnim.Play("TestTube3-PourTo1");
                //ONE OVER THREE ANIMATION
            }
        }

        else if (twoRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TwoToOne();
                handsAnim.Play("HandTestTube2-PourTo3");
                vialAnim.Play("TestTube2-PourTo3");
                //TWO OVER ONE ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                twoRaised = false;
                handsAnim.Play("HandTestTube2-Down");
                vialAnim.Play("TestTube2-Down");
                //VIAL TWO DOWN ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TwoToThree();
                handsAnim.Play("HandTestTube2-PourTo1");
                vialAnim.Play("TestTube2-PourTo1");
                //TWO OVER THREE ANIMATION
            }
        }

        else if (threeRaised)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ThreeToOne();
                handsAnim.Play("HandTestTube1-PourTo3");
                vialAnim.Play("TestTube1-PourTo3");
                //THREE OVER ONE ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ThreeToTwo();
                handsAnim.Play("HandTestTube1-PourTo2");
                vialAnim.Play("TestTube1-PourTo2");
                //THREE OVER TWO ANIMATION
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                threeRaised = false;
                handsAnim.Play("HandTestTube1-Down");
                vialAnim.Play("TestTube1-Down");
                //VIAL THREE DOWN ANIMATION
            }
        }
    }


    IEnumerator Purified()
    {
        yield return new WaitForSeconds(1.8f);
        Debug.Log("hurrhaa");
        GM.purified = true;
        GM.WaterPurified();
    }
    public void OneToTwo()
    {
        if (vialTwo[0].enabled && vialTwo[1].enabled && vialTwo[2].enabled)
        {
            FullTube();
        }

        else if (!vialTwo[0].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialOne[i].enabled)
                {
                    vialTwo[0].material = vialOne[i].material;
                    vialTwo[0].enabled = true;
                    vialOne[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 1 is empty!");
                }
            }
        }

        else if (!vialTwo[1].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialOne[i].enabled)
                {
                    vialTwo[1].material = vialOne[i].material;
                    vialTwo[1].enabled = true;
                    vialOne[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 1 is empty!");
                }
            }
        }

        else if (!vialTwo[2].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialOne[i].enabled)
                {
                    vialTwo[2].material = vialOne[i].material;
                    vialTwo[2].enabled = true;
                    vialOne[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 1 is empty!");
                }
            }
        }

        /*else if (!vialTwo[0].enabled)
        {
            if (vialOne[2].enabled)
            {
                vialTwo[0].material = vialOne[2].material;
                vialTwo[0].enabled = true;
                vialOne[2].enabled = false;
            }

            else if (vialOne[1].enabled)
            {
                vialTwo[0].material = vialOne[1].material;
                vialTwo[0].enabled = true;
                vialOne[1].enabled = false;
            }

            else if (vialOne[0].enabled)
            {
                vialTwo[0].material = vialOne[0].material;
                vialTwo[0].enabled = true;
                vialOne[0].enabled = false;
            }

            else
            {
                Debug.Log("vial 1 empty!");
            }
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

        else if (!vialTwo[2].enabled)
        {
            if (vialOne[2].enabled)
            {
                vialTwo[2].material = vialOne[2].material;
                vialTwo[2].enabled = true;
                vialOne[2].enabled = false;
            }

            else if (vialOne[1].enabled)
            {
                vialTwo[2].material = vialOne[1].material;
                vialTwo[2].enabled = true;
                vialOne[1].enabled = false;
            }

            else if (vialOne[0].enabled)
            {
                vialTwo[2].material = vialOne[0].material;
                vialTwo[2].enabled = true;
                vialOne[0].enabled = false;
            }

            else
            {
                Debug.Log("vial 1 empty!");
            }
        }*/
    }

    public void FullTube()
    {
        tubeFull.SetActive(true);
        StartCoroutine(Deac());
    }

    IEnumerator Deac()
    {
        yield return new WaitForSeconds(1.5f);
        tubeFull.SetActive(false);
    }
    public void OneToThree()
    {
        if (vialThree[0].enabled && vialThree[1].enabled && vialThree[2].enabled)
        {
            FullTube();
        }

        else if (!vialThree[0].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialOne[i].enabled)
                {
                    vialThree[0].material = vialOne[i].material;
                    vialThree[0].enabled = true;
                    vialOne[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 1 is empty!");
                }
            }
        }

        else if (!vialThree[1].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialOne[i].enabled)
                {
                    vialThree[1].material = vialOne[i].material;
                    vialThree[1].enabled = true;
                    vialOne[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 1 is empty!");
                }
            }
        }

        else if (!vialThree[2].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialOne[i].enabled)
                {
                    vialThree[2].material = vialOne[i].material;
                    vialThree[2].enabled = true;
                    vialOne[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 1 is empty!");
                }
            }
        }
    }

    public void TwoToOne()
    {
        if (vialOne[0].enabled && vialOne[1].enabled && vialOne[2].enabled)
        {
            FullTube();
        }

        else if (!vialOne[0].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialTwo[i].enabled)
                {
                    vialOne[0].material = vialTwo[i].material;
                    vialOne[0].enabled = true;
                    vialTwo[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 2 is empty!");
                }
            }
        }

        else if (!vialOne[1].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialTwo[i].enabled)
                {
                    vialOne[1].material = vialTwo[i].material;
                    vialOne[1].enabled = true;
                    vialTwo[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 2 is empty!");
                }
            }
        }

        else if (!vialOne[2].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialTwo[i].enabled)
                {
                    vialOne[2].material = vialTwo[i].material;
                    vialOne[2].enabled = true;
                    vialTwo[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 2 is empty!");
                }
            }
        }
    }

    public void TwoToThree()
    {
        if (vialThree[0].enabled && vialThree[1].enabled && vialThree[2].enabled)
        {
            Debug.Log("vial 3 full!");
        }

        else if (!vialThree[0].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialTwo[i].enabled)
                {
                    vialThree[0].material = vialTwo[i].material;
                    vialThree[0].enabled = true;
                    vialTwo[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 2 is empty!");
                }
            }
        }

        else if (!vialThree[1].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialTwo[i].enabled)
                {
                    vialThree[1].material = vialTwo[i].material;
                    vialThree[1].enabled = true;
                    vialTwo[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 2 is empty!");
                }
            }
        }

        else if (!vialThree[2].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialTwo[i].enabled)
                {
                    vialThree[2].material = vialTwo[i].material;
                    vialThree[2].enabled = true;
                    vialTwo[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 2 is empty!");
                }
            }
        }
    }

    public void ThreeToOne()
    {
        if (vialOne[0].enabled && vialOne[1].enabled && vialOne[2].enabled)
        {
            Debug.Log("vial 1 full!");
        }

        else if (!vialOne[0].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialThree[i].enabled)
                {
                    vialOne[0].material = vialThree[i].material;
                    vialOne[0].enabled = true;
                    vialThree[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 3 is empty!");
                }
            }
        }

        else if (!vialOne[1].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialThree[i].enabled)
                {
                    vialOne[1].material = vialThree[i].material;
                    vialOne[1].enabled = true;
                    vialThree[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 3 is empty!");
                }
            }
        }

        else if (!vialOne[2].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialThree[i].enabled)
                {
                    vialOne[2].material = vialThree[i].material;
                    vialOne[2].enabled = true;
                    vialThree[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 3 is empty!");
                }
            }
        }
    }

    public void ThreeToTwo()
    {
        if (vialTwo[0].enabled && vialTwo[1].enabled && vialTwo[2].enabled)
        {
            Debug.Log("vial 2 full!");
        }

        else if (!vialTwo[0].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialThree[i].enabled)
                {
                    vialTwo[0].material = vialThree[i].material;
                    vialTwo[0].enabled = true;
                    vialThree[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 3 is empty!");
                }
            }
        }

        else if (!vialTwo[1].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialThree[i].enabled)
                {
                    vialTwo[1].material = vialThree[i].material;
                    vialTwo[1].enabled = true;
                    vialThree[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 3 is empty!");
                }
            }
        }

        else if (!vialTwo[2].enabled)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (vialThree[i].enabled)
                {
                    vialTwo[2].material = vialThree[i].material;
                    vialTwo[2].enabled = true;
                    vialThree[i].enabled = false;
                    break;
                }

                else
                {
                    Debug.Log("Vial 3 is empty!");
                }
            }
        }
    }
}
