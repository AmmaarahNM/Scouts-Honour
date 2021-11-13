using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingGame : MonoBehaviour
{
    public GameManager GM;
    public Slider reelSlider;
    public GameObject sliderIcon;
    bool isIncreasing = true;
    bool isCasting;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderIcon.SetActive(GM.rodActive);
        if (GM.rodActive)
        {
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                isCasting = true;
                if (isIncreasing)
                {
                    if (reelSlider.value < 1)
                    {
                        reelSlider.value += Time.deltaTime;
                    }

                    else
                    {
                        isIncreasing = false;
                    }
                    
                }

                else
                {
                    if (reelSlider.value > 0)
                    {
                        reelSlider.value -= Time.deltaTime;
                    }

                    else
                    {
                        isIncreasing = true;
                    }
                }

                
            }

            else
            {
                isCasting = false;
            }

            if (reelSlider.value > 0 && !isCasting)
            {
                range = reelSlider.value * 20; //TEST THIS VALUE!
                Debug.Log(range);
                GM.FishingOutcome(range);
                StartCoroutine(DelayReset());
                //activate CastLine();
                
            }


        }
    }

    IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(0.5f);
        reelSlider.value = 0;
    }

    void CastLine()
    {
        //instantiate trigger at raycast position (distance of range)
        reelSlider.value = 0;
    }
}
