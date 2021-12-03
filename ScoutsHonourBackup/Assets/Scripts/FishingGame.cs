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
    
    public float range;
    public LayerMask fishLayer;
    public GameObject hands;
    public Text fishingInfo;
    public GameObject fishingInfoText;

    public bool isCasting;
    public bool isReeling;
    public bool canReel;
    public bool hitFish;

    public GameObject reelingBar;
    public Image reelValue;
    float storedRange;
    GameObject storedFishObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reelingBar.SetActive(canReel);
        reelValue.fillAmount = (range / storedRange);
        sliderIcon.SetActive(GM.rodActive && !canReel);
        if (GM.rodActive)
        {
            
            if (Input.GetKey(KeyCode.Mouse0) && !canReel)
            {
                if (!GM.fishCaught)
                {
                    isCasting = true;             //ONLY IF NO FISH IN INVENTORY - OTHERWISE SAY FISH AREALDY CAUGHT
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
                    GM.StorageFull();
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
                
                fishingInfo.text = "Casting...";
                fishingInfoText.SetActive(true);
                StartCoroutine(DelayReset());
                //CastLine();
                
            }

            if (canReel)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    isReeling = true;
                    fishingInfo.text = "Reeling";
                }

                else
                {
                    isReeling = false;
                    fishingInfo.text = "Fish caught! Time to reel it in (hold spacebar)";
                }
            }

            else
            {
                isReeling = false;
            }

            if (isReeling)
            {
                if (range > 0)
                {
                    range -= 4 * Time.deltaTime;
                }

                else
                {
                    GM.FishingOutcome();
                    fishingInfo.text = "";
                    canReel = false;
                    hitFish = false;

                }
            }


        }

        else
        {
            fishingInfoText.SetActive(false);
        }
    }

    IEnumerator DelayReset()
    {
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, new Vector3(1, 1, 1) * range, Color.red);
        //Debug.DrawRay(new Vector3(GM.cam.transform.position.x, GM.cam.transform.position.y - 2, GM.cam.transform.position.z), new Vector3 (1,1,1) * range, Color.red);
        Debug.DrawRay(new Vector3(hands.transform.position.x, hands.transform.position.y - 1.5f, hands.transform.position.z), (transform.forward) * range, Color.red);
        if (Physics.Raycast(new Vector3(hands.transform.position.x, hands.transform.position.y - 1.5f, hands.transform.position.z), (transform.forward), out hit, range, fishLayer))
        {
            
            if (hit.collider.gameObject.tag == "fish")
            {
                Debug.Log("fish caught");
                hitFish = true;
                hit.collider.gameObject.SetActive(false);
                storedFishObj = hit.collider.gameObject;
                //deactivate that fish
                
            }
            else
            {
                Debug.Log("no fish caught");
                
            }


            
        }

        yield return new WaitForSeconds(1f);
        if (hitFish)
        {
            fishingInfo.text = "Fish caught! Time to reel it in (hold spacebar)";
            storedRange = range;
            canReel = true;
            
        }

        else
        {
            fishingInfo.text = "No luck! Try again!";
        }
        reelSlider.value = 0;
        StartCoroutine(ReactivateFish());
    }

    IEnumerator ReactivateFish()
    {
        yield return new WaitForSeconds(15);
        storedFishObj.SetActive(true);
    }

   

}
