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
    public LayerMask fishLayer;
    public GameObject hands;
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
                
                StartCoroutine(DelayReset());
                //CastLine();
                
            }


        }
    }

    IEnumerator DelayReset()
    {
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //Debug.DrawRay(ray.origin, (Vector3.forward) * range, Color.red);
        Debug.DrawRay(new Vector3(transform.localPosition.x, transform.localPosition.y - 2, transform.localPosition.z), (Vector3.forward) * range, Color.red);
        //Debug.DrawRay(new Vector3(hands.transform.position.x, hands.transform.position.y - 2, hands.transform.position.z), (Vector3.forward) * range, Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), Vector3.forward, range, fishLayer))
        {
            Debug.Log("fish caught");
            //deactivate that fish
            //GM.FishingOutcome(range); but change the range 11 bit in the fn
        }

        else
        {
            Debug.Log("no fish caught");
        }

        yield return new WaitForSeconds(1f);
        reelSlider.value = 0;
    }

    void CastLine()
    {
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(new Vector3(transform.localPosition.x, transform.localPosition.y - 2, transform.localPosition.z), Vector3.forward * range, Color.red); 
        //instantiate trigger at raycast position (distance of range)
        reelSlider.value = 0;
    }
}
