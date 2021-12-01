using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject storageFullUI;

    public Image fedBar;
    public Image hydratedBar;
    public Image energyBar;
    public Image healthBar;

    public GameObject FoodWarning;
    public GameObject WaterWarning;
    public GameObject EnergyWarning;
    public GameObject HealthWarning;

    float fed = 100;
    float hydrated = 100;
    float energy = 100;
    float health = 100;

    bool isEating;
    bool isResting;
    bool isDrinking;

    bool isEatingMango;
    public GameObject mangoDangerInfo;

    public bool waterCollected;
    bool woodCollected;
    public bool fishCaught;

    public bool collectWaterEnabled;
    public GameObject collectWaterPrompt;
    public GameObject collectingWater;

    public bool LogEnabled;
    public GameObject RestLog;

    public bool collectWoodEnabled;
    public GameObject collectWoodPrompt;
    public GameObject collectingWood;
    int numberOfLogs;
    public Text numberOfLogsUI;

    public GameObject hasWater;
    public GameObject hasFish;
    public GameObject hasWood;

    public GameObject waterInventory;
    public GameObject fishInventory;
    public GameObject woodInventory;


    public bool startFishingEnabled;
    public GameObject fishingRodPrompt;
    public GameObject fishingRod;
    public bool rodActive;

    public CharacterController controller;
    public PlayerMovement PM;

    public GameObject compass;

    public GameObject journal;
    public bool journalOpen;
    public MouseLook ML;
    //public GameObject journalPrompt;

    public CollectionUI woodScript;
    public CollectionUI waterScript;

    public bool startFireEnabled;
    public GameObject setUpLogsPrompt;
    public Text setUpLogsText;
    public bool logsActive;
    public GameObject fireplaceLogs;

    Vector2 mousePos;
    public Camera cam;
    public GameObject sticks;
    public GameObject stick;
    public bool fireStarted;
    
    public GameObject fireBadge;
    public GameObject fireBadgeAchievement;
    public GameObject floraBadge;
    public GameObject floraBadgeAchievement;
    public GameObject birdBadge;
    public GameObject birdBadgeAchievement;
    public GameObject fishingBadge;
    public GameObject fishingBadgeAchievement;
    public GameObject objectivesBadge;
    public GameObject objectivesBadgeAchievement;
    public GameObject toolsBadge;
    public GameObject toolsBadgeAchievement;

    public GameObject noFireBadge;
    public GameObject noFloraBadge;
    public GameObject noBirdBadge;
    public GameObject noFishBadge;
    public GameObject noObjectivesBadge;
    public GameObject noToolsBadge;

    public int birdsFound;

    //Sounds
    public GameObject WaterSound;
    public GameObject CampSound;
    public GameObject FireEffect;
    public GameObject WoodPlacementSound;

    public GameObject inventoryBag;
    public bool inventoryOpen;

    public GameObject collectAloePrompt;
    public GameObject collectGingerPrompt;
    public bool collectAloeEnabled;
    public bool collectGingerEnabled;

    public GameObject[] aloeUI;
    public GameObject aloeInventory;
    bool aloeCollected;

    public GameObject[] gingerUI;
    public GameObject gingerInventory;
    bool gingerCollected;

    /*public int pointsExplored;
    public GameObject exploreBadge;
    public Text exploredArea;*/

    public bool gamePaused;
    public GameObject escapeTab;

    public GameObject[] completeObjectiveTick;
    bool[] firstTime = new bool[9];

    public GameObject pickUpAxePrompt;
    public bool axeSeen;
    public bool axeCollected;
    public GameObject axe1;
    public GameObject axe2;
    bool axeActive;
    //public GameObject axeInBag;
    //public GameObject activateAxePrompt;
    public GameObject axeInventory;

    public bool isFire;

    public bool collectPlumEnabled;
    public bool collectAppleEnabled;
    public bool collectMangoEnabled;

    int numberOfApples;
    int numberOfPlums;
    int numberOfMangos;

    public GameObject collectApplePrompt;
    public GameObject collectPlumPrompt;
    public GameObject collectMangoPrompt;

    public GameObject appleInventory;
    //bool appleCollected;
    public GameObject plumInventory;
    //bool plumCollected;
    public GameObject mangoInventory;
    //bool mangoCollected;

    public bool activateChemSet;
    public GameObject purifyPrompt;
    public bool chemSetOpen;
    public GameObject chemistrySet;

    public GameObject eatApplePrompt;
    public GameObject eatPlumPrompt;
    public GameObject eatMangoPrompt;

    public GameObject eatingAppleUI;
    public GameObject eatingPlumUI;
    public GameObject eatingMangoUI;

    public Text numberOfLogsInv;
    public Text numberOfApplesInv;
    public Text numberOfPlumsInv;
    public Text numberOfMangosInv;

    public GameObject[] journalApple;
    public GameObject[] journalPlum;
    public GameObject[] journalMango;

    //public GameObject hands;

    public GameObject movingToBag;
    public Image addingIcon;
    public Sprite[] addingImages;
    //bool addingToInventory;

    bool isPoisoned;
    bool isBurnt;
    bool isBurning;
    bool isHealing;
    public GameObject isBurningInfo;

    public GameObject eatingGingerUI;
    public GameObject eatingAloeUI;
    public GameObject eatGingerPrompt;
    public GameObject eatAloePrompt;

    public GameObject dangerUI;
    bool barOnZero;
    public GameObject BagGlow;
    public bool newItems;

    public GameObject poisonedIcon;
    public GameObject burntIcon;

    public Text bagUpdates;
    public GameObject unequipRod;
    public GameObject unequipAxePrompt;
    public GameObject packChemSetPrompt;
    public GameObject closeJournalPrompt;
    //public GameObject textBackground;
    public TerrainActivationTriggers[] terrainScripts;

    public bool firstFishCaught;

    public GameObject restingUI;
    Vector3 previousPosition;
    Vector3 previousRotation;

    public float energyDecrease;

    bool firstAloe;
    bool firstGinger;
    bool firstApple;
    bool firstPlum;
    bool firstMango;

    public GameObject newPlantInfo;

    public bool fishInvClicked;
    public GameObject cookFishPrompt;
    public bool canCookFish;
    public GameObject rawFishPrompt;
    float cookingTime;
    public GameObject rawFishDangerInfo;
    bool isEatingFish;
    bool fishReady;
    bool fishCooking;
    public GameObject eatingFishUI;
    public GameObject eatCookedFishPrompt;
    public GameObject burntFishUI;

    public GameObject rawFishAnim;
    public GameObject cookedFishAnim;
    public GameObject burntFishAnim;

    public bool binocsActive;
    public GameObject binocUI;
    public GameObject binocText;
    public Text birdName;
    public GameObject newBirdInfo;

    int objectivesTicked;
    public GameObject lostUI;
    public GameObject badgesEnd;
    public GameObject objectivesEndBadge;
    public GameObject floraEndBadge;
    public GameObject fishEndBadge;
    public GameObject fireEndBadge;
    public GameObject birdEndBadge;
    public GameObject toolsEndBadge;

    public GameObject winUI;

    public bool purified;
    public PurifierManager Purif;
    public GameObject chemInfo;

    public GameObject drinkingWaterUI;
    public GameObject dirtyWaterDangerInfo;
    public GameObject dirtyWaterPrompt;
    public GameObject cleanWaterPrompt;

    public GameObject dirtyWater;
    public GameObject cleanWater;
    public bool nestSeen;

    public GameObject collectEggsPrompt;
    public GameObject noToEggs;
    public GameObject startLetter;
    public bool letterClosed;
    public GameObject waterPurifiedNotif;

    public GameObject sticksInfo;
    public GameObject comeCloserPrompt;
    public GameObject cookFishInvPrompt;

    bool axeUsed;
    bool compassUsed;
    bool chemUsed;
    bool rodUsed;
    bool binocsUsed;
    bool firstUseRegister;
    //PrefabActivation[] prefabScripts;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Time.timeScale = 0;
        gamePaused = true;
        startLetter.SetActive(true);
        energyDecrease = 4;
        ML.enabled = false;

        //prefabScripts = FindObjectsOfTypeAll<PrefabActivation>();

    }

    public void BeginGame()
    {
        gamePaused = false;
        startLetter.SetActive(false);
        Time.timeScale = 1;
        letterClosed = true;
        ML.enabled = true;
    }

     
    // Update is called once per frame
    void FixedUpdate()
    {
        numberOfLogsInv.text = numberOfLogs.ToString() + "/15";
        numberOfApplesInv.text = numberOfApples.ToString() + "/3";
        numberOfPlumsInv.text = numberOfPlums.ToString() + "/3";
        numberOfMangosInv.text = numberOfMangos.ToString() + "/3";

        poisonedIcon.SetActive(isPoisoned);
        burntIcon.SetActive(isBurnt);

        chemInfo.SetActive(chemSetOpen);
        
       /* foreach (TerrainActivationTriggers terrain in terrainScripts)
        {
            terrain.terrainPiece.SetActive(terrain.inRangeOfTerrain);
        }       */                                                          ///TERRAIN STUFF NB

        /*if (rodActive || gamePaused || axeActive || chemSetOpen)
        {
            hands.SetActive(false);
        }

        else
        {
            hands.SetActive(true);
        }*/
        if (firstAloe && firstApple && firstGinger && firstMango && firstPlum)
        {
            ObjectivesCompleted(7);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && letterClosed)
        {
            gamePaused = true;
            escapeTab.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.I) && !journalOpen)
        {
            inventoryOpen = true;
            BagGlow.SetActive(false);
            ActivateInventory();

        }

        if (binocsActive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.fieldOfView > 20)
            {
                cam.fieldOfView--;
                binocText.SetActive(false);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.fieldOfView < 55)
            {
                cam.fieldOfView++;
            }


        }

        if (compassUsed && chemUsed && rodUsed && axeUsed && binocsUsed)
        {
            if (!firstUseRegister)
            {
                toolsBadge.SetActive(true);
                toolsEndBadge.SetActive(true);
                noToolsBadge.SetActive(false);
                toolsBadgeAchievement.SetActive(true);
                firstUseRegister = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (binocsActive)
            {
                binocsActive = false;
                binocUI.SetActive(false);
                cam.fieldOfView = 60;
            }

            else
            {
                binocsUsed = true;
                binocsActive = true;
                binocUI.SetActive(true);
                cam.fieldOfView = 40;
            }
        }

        //journal.SetActive(journalOpen);

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (journalOpen)
            {
                CloseJournal();
                CloseInventory();
            }

            else
            {
                inventoryOpen = true;
                ActivateInventory();
                OpenJournal();
            }
        }

        closeJournalPrompt.SetActive(journalOpen);
        unequipAxePrompt.SetActive(axeActive);
        unequipRod.SetActive(rodActive);
        packChemSetPrompt.SetActive(chemSetOpen);

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (axeCollected)
            {
                
                if (axeActive)
                {
                    axe2.SetActive(false);
                    axeActive = false;
                }

                else
                {
                    axe2.SetActive(true);
                    axeActive = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateChemSet();
        }

        if (Input.GetKey(KeyCode.C))
        {
            compass.SetActive(true);
            compassUsed = true;
        }

        else
        {
            compass.SetActive(false);
        }
        /// CONDITION BARS DECREASING OVER TIME
        if (fed > 0.1 && !isEating && !inventoryOpen)
        {
            fed -= (Time.deltaTime) / 3;
        }
        fedBar.fillAmount = fed / 100;

        if (hydrated > 1 && !isDrinking && !inventoryOpen)
        {
            hydrated -= (Time.deltaTime) / 4;
        }
        hydratedBar.fillAmount = hydrated / 100;

        if (energy > 1 && !isResting && !inventoryOpen)
        {
            energy -= (Time.deltaTime) / energyDecrease;
        }
        energyBar.fillAmount = energy / 100;

        if (numberOfApples <= 0)
        {
            //appleCollected = false;
            appleInventory.SetActive(false);
        }

        if (numberOfPlums <= 0)
        {
            //plumCollected = false;
            plumInventory.SetActive(false);
        }

        if (numberOfMangos <= 0)
        {
            //mangoCollected = false;
            mangoInventory.SetActive(false);
        }


        /// CONDITION BARS INCREASING WITH ACTIONS (need to first activate these bools in-game)
        if (isEating && fed < 100)
        {
            fed += 6 * Time.deltaTime;

            //amountFed += 2 * Time.deltaTime;
            //set bool false once amountFed has reached desired value;
        }

        if (isEatingFish && fed < 100)
        {
            fed += 8 * Time.deltaTime;
        }

        if (isEatingMango || isBurning)
        {
            health -= 3*Time.deltaTime;
            Debug.Log("health should decrease!");
        }

        if ((isBurnt || isPoisoned) && (!isEatingMango && !isBurning) )
        {
            health -= Time.deltaTime/2;
        }

        if (isHealing)
        {
            if (health < 100)
            health += 10 * Time.deltaTime;
        }

        healthBar.fillAmount = health / 100;

        if (health <= 0.8)
        {
            LoseCondition();
        }


        if (isDrinking && hydrated < 100)
        {
            hydrated += 20 * Time.deltaTime;

            //amountDrank += 2 * Time.deltaTime;
            //set bool false once amountDrank has reached desired value;
        }

        if (isResting && energy < 100)
        {
            energy += 5 * Time.deltaTime;

            //amountRested += 2 * Time.deltaTime;
            //set bool false once amountRested has reached desired value;
        }

        /// LOSE CONDITION
        if (fed <= 1)
               
        {
            barOnZero = true;
            
        }

       

        else if (hydrated <= 1)
        {
            barOnZero = true;
            
        }

    

        else if (energy <= 1)
        {
            barOnZero = true;
            
        }

        else
        {
            barOnZero = false;
        }

   

        if (fed <= 10)

        {
            
            FoodWarning.SetActive(true);
        }

        else
        {
           
            FoodWarning.SetActive(false);
        }

        if (hydrated <= 10)
        {
            
            WaterWarning.SetActive(true);
        }

        else
        {
           
            WaterWarning.SetActive(false);
        }

        if (energy <= 10)
        {
            
            EnergyWarning.SetActive(true);
        }

        else
        {
            
            EnergyWarning.SetActive(false);
        }

        if (barOnZero)
        {
            dangerUI.SetActive(true);
            HealthWarning.SetActive(true);
            if (health > 0.1)
            {
                health -= Time.deltaTime ;
            }

            else
            {
                Debug.Log("YOU LOST GAME OVER");
            }
        }

        else
        {
            if (!isBurnt && !isPoisoned)
            {
                dangerUI.SetActive(false);
            }
        }

        ///TRIGGER COLLECTING STUFF
        ///
        if (nestSeen)
        {
            collectEggsPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                noToEggs.SetActive(true);
            }
        }

        else
        {
            collectEggsPrompt.SetActive(false);
        }
        if (collectAloeEnabled)
        {
            collectAloePrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!aloeCollected)
                {
                    AloeCollection();
                    
                }

                else
                {
                    Debug.Log("aloe already collected");
                    StorageFull();
                }
                
            }
        }

        else
        {
            collectAloePrompt.SetActive(false);
        }

        if (collectAppleEnabled)
        {
            collectApplePrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (numberOfApples < 3)
                {
                    CollectApple();
                }

                else
                {
                    Debug.Log("apple storage full");
                    StorageFull();
                }
            }
        }

        else
        {
            collectApplePrompt.SetActive(false);
        }

        if (collectPlumEnabled)
        {
            collectPlumPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (numberOfPlums < 3)
                {
                    CollectPlum();
                }

                else
                {
                    StorageFull();
                }
            }
        }

        else
        {
            collectPlumPrompt.SetActive(false);
        }

        if (collectMangoEnabled)
        {
            collectMangoPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (numberOfMangos < 3)
                {
                    CollectMango();
                }

                else
                {
                    StorageFull();
                }
            }
        }

        else
        {
            collectMangoPrompt.SetActive(false);
        }


        if (collectGingerEnabled)
        {
            collectGingerPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!gingerCollected)
                {
                    GingerCollection();
                }

                else
                {
                    StorageFull();
                }

            }
        }

        else
        {
            collectGingerPrompt.SetActive(false);
        }

        if (collectWoodEnabled && !axeSeen)
        {
            /*if (axeCollected) //&& inFrontOfTree
            {
                if (!axeActive)
                {
                    activateAxePrompt.SetActive(true);
                }

                else
                {
                    activateAxePrompt.SetActive(false);
                }

               /* if (Input.GetKeyDown(KeyCode.A) && axeCollected)
                {
                    if (!axeActive)
                    {
                        axe2.SetActive(true);
                        axeActive = true;
                    }

                    else
                    {
                        axe2.SetActive(false);
                        axeActive = false;
                    }
                }
            }*/
            collectWoodPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (numberOfLogs >= 15)
                {
                    StorageFull();
                }

                else
                {
                    CollectWood();
                    ObjectivesCompleted(1);
                }
                
            }
        }

        else
        {
            collectWoodPrompt.SetActive(false);
            //activateAxePrompt.SetActive(false);
            //axe2.SetActive(false);
            //axeActive = false;
        }

        if (collectWaterEnabled)
        {
            collectWaterPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (waterCollected)
                {
                    StorageFull();
                }

                else
                {
                    WaterSound.SetActive(true);
                    CollectWater();
                    ObjectivesCompleted(3);
                }
                
            }
        }

        else
        {
            collectWaterPrompt.SetActive(false);
        }

        if (LogEnabled && !isResting)
        {
            RestLog.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                RestFunction();
                

            }
        }

        else
        {
            RestLog.SetActive(false);
        }

        if (axeSeen)
        {
            pickUpAxePrompt.SetActive(true);
            AxeCollection();
        }

        else
        {
            pickUpAxePrompt.SetActive(false);
        }

        if (activateChemSet && waterCollected)
        {
            purifyPrompt.SetActive(true);
        }

        else
        {
            purifyPrompt.SetActive(false);
        }

        if (startFishingEnabled)
        {
            fishingRod.SetActive(rodActive);
            fishingRodPrompt.SetActive(!rodActive);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (rodActive)
                {
                    rodActive = false;
                    controller.enabled = true;
                }

                else
                {
                    rodActive = true;
                    fishingRodPrompt.SetActive(false);
                    controller.enabled = false;
                    //link mouse to fishing rod
                }
            }
        }

        else
        {
            fishingRodPrompt.SetActive(false);
        }

        if (startFireEnabled)
        {
            if (!logsActive)
            {
                setUpLogsPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (numberOfLogs >= 10)
                    {
                        setUpLogsPrompt.SetActive(false);
                        numberOfLogs -= 1;
                        numberOfLogsUI.text = numberOfLogs.ToString() + "/10";
                        fireplaceLogs.SetActive(true);
                        WoodPlacementSound.SetActive(true);
                        logsActive = true;

                        if (numberOfLogs <= 0)
                        {
                            woodCollected = false;
                        }

                    }

                    else
                    {
                        //setUpLogsPrompt.SetActive(false);
                        setUpLogsText.text = "Need 10 wood to build a fire!";
                        //deactivate setup prompt and activate not enough logs UI
                        Debug.Log("not enough logs!!!");
                    }
                }
            }

            else
            {
                if (!fireStarted)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PM.enabled = false;
                    ML.enabled = false;
                  //CampSound.SetActive(true); //wait till fire started
                    sticks.SetActive(true);
                    sticksInfo.SetActive(true);
                  //stick.transform.position = mousePos;
                     // cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 5));
                    //lock mouse pos to stick
                    //deactivate charater controller and mouse look, etc
                    //prompt player to move stick to start fire
                    //do a velocity check - activate another bool when reached - fireStarted
                }

                else
                {
                    //CampSound.SetActive(true);
                    FireEffect.SetActive(true);
                    sticks.SetActive(false);
                    fireBadge.SetActive(true);
                    isFire = true;
                    sticksInfo.SetActive(false);
                    //fireBadgeAchievement.SetActive(true);
                    //activate fire and particle effect stuff
                    StartCoroutine(ReactivateMouse());
                    
                    //StartCoroutine(FireOut());

                    if (fishCaught)
                    {
                        cookFishPrompt.SetActive(true);
                        canCookFish = true;
                    }
                    
                }
            }
        }

        else
        {
            setUpLogsPrompt.SetActive(false);
            setUpLogsText.text = "Setup fireplace logs (E)";
            cookFishPrompt.SetActive(false);
            canCookFish = false;
        }

        if (fishCooking)
        {
            cookingTime += Time.deltaTime;

            if (cookingTime <= 7)
            {
                rawFishAnim.SetActive(true);
                cookedFishAnim.SetActive(false);
                burntFishAnim.SetActive(false);
                cookFishPrompt.SetActive(false);
            }

            else if (cookingTime > 7 && cookingTime <= 12)
            {
                rawFishAnim.SetActive(false);
                fishReady = true;
                cookedFishAnim.SetActive(true);
                burntFishAnim.SetActive(false);
                eatCookedFishPrompt.SetActive(true);
            }

            else
            {
                rawFishAnim.SetActive(false);
                cookedFishAnim.SetActive(false);
                burntFishAnim.SetActive(true);
                eatCookedFishPrompt.SetActive(false);
                burntFishUI.SetActive(true);
                
                fishReady = false;
                StartCoroutine(DeactivateBurntFish());
            }
        }

        else
        {
            rawFishAnim.SetActive(false);
            cookedFishAnim.SetActive(false);
            burntFishAnim.SetActive(false);
            eatCookedFishPrompt.SetActive(false);
            cookingTime = 0;
        }

     

        
        /// PLAYER HAS RESOURCES UI
        //hasWater.SetActive(waterCollected);
        //hasWood.SetActive(woodCollected);
        //hasFish.SetActive(fishCaught);
        if (Input.GetKeyDown(KeyCode.E) && fishReady)
        {
            if (startFireEnabled)
            {
                comeCloserPrompt.SetActive(false);
                EatCookedFish();
            }

            else
            {
                comeCloserPrompt.SetActive(true);
            }
            
        }

        

        waterInventory.SetActive(waterCollected);
        woodInventory.SetActive(woodCollected);
        fishInventory.SetActive(fishCaught);

        

    }

    IEnumerator DeactivateBurntFish()
    {
        yield return new WaitForSeconds(2);
        fishCooking = false;
        burntFishAnim.SetActive(false);
        burntFishUI.SetActive(false);
    }

    public void EatCookedFish()
    {
        fishCooking = false;
        fishReady = false;

        eatApplePrompt.SetActive(false);
        isEatingFish = true;
        eatingFishUI.SetActive(true);
        CloseInventory();
        controller.enabled = false;
        
        //eating sound
        StartCoroutine(StopEatingFish());

    }

    IEnumerator StopEatingFish()
    {
        yield return new WaitForSeconds(2);
        isEatingFish = false;
        controller.enabled = true;
        eatingFishUI.SetActive(false);
    }

    public void SelectCookFish()
    {
        CloseInventory();
        fishCaught = false;
        fishInventory.SetActive(false);
        fishInvClicked = false;
        fishCooking = true;
        canCookFish = false;
        cookFishInvPrompt.SetActive(false);
    }
    public void FishInventoryClicked()
    {
        if (canCookFish)
        {
            cookFishInvPrompt.SetActive(true);
            //Activate cooking UI
            //Timer thing for burnt or not
            
        }

        else
        {
            rawFishPrompt.SetActive(true);
        }
    }

    public void WaterPurified()
    {
        Debug.Log("Water purified");
        chemUsed = true;
        ActivateChemSet();
        waterPurifiedNotif.SetActive(true);
        dirtyWater.SetActive(false);
        cleanWater.SetActive(true);
        //prompt saying water is purified
        purified = true;
    }

    public void DrinkDirtyWater()
    {
        waterCollected = false;
        dirtyWaterPrompt.SetActive(false);
        CloseInventory();
        isEatingMango = true;
        controller.enabled = false;
        drinkingWaterUI.SetActive(true);
        waterInventory.SetActive(false);
        StartCoroutine(StopDrinkingDirty());
    }

    IEnumerator StopDrinkingDirty()
    {
        yield return new WaitForSeconds(1);
        isEatingMango = false;
        controller.enabled = true;
        drinkingWaterUI.SetActive(false);
        dirtyWaterDangerInfo.SetActive(true);
        isPoisoned = true;
        dangerUI.SetActive(true);

        yield return new WaitForSeconds(3);
        dirtyWaterDangerInfo.SetActive(false);
        dangerUI.SetActive(false);
    }

    public void DrinkCleanWater()
    {
        waterCollected = false;
        
        cleanWaterPrompt.SetActive(false);
        CloseInventory();
        isDrinking = true;
        controller.enabled = false;
        drinkingWaterUI.SetActive(true);
        waterInventory.SetActive(false);
        Purif.vialOneReady = false;
        Purif.vialThreeReady = false;
        Purif.vialTwoReady = false;
        purified = false;
        StartCoroutine(StopDrinking());
    }

    IEnumerator StopDrinking()
    {
        yield return new WaitForSeconds(2);
        isDrinking = false;
        controller.enabled = true;
        drinkingWaterUI.SetActive(false);
    }
    public void RestFunction()
    {
        isResting = true;
        previousPosition = PM.gameObject.transform.position;
        previousRotation = PM.gameObject.transform.eulerAngles;
        controller.enabled = false;
        restingUI.SetActive(true);


        PM.gameObject.transform.position = new Vector3(65.6f, 3f, 64f);
        PM.gameObject.transform.eulerAngles = new Vector3(1, 185.2f, 0);
        StartCoroutine(RestOver());
    }

    IEnumerator RestOver()
    {
        yield return new WaitForSeconds(4);
        isResting = false;
        PM.gameObject.transform.position = previousPosition;
        PM.gameObject.transform.eulerAngles = previousRotation;
        controller.enabled = true;
        restingUI.SetActive(false);
        

    }

    IEnumerator ReactivateMouse()
    {
        //fireBadgeAchievement.SetActive(true);
        yield return new WaitForSeconds(3);
        fireBadgeAchievement.SetActive(false);
        if (!inventoryOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PM.enabled = true;
            ML.enabled = true;
        }
        
    }

    IEnumerator FireOut()
    {
        yield return new WaitForSeconds(10);
        CampSound.SetActive(false);
        FireEffect.SetActive(false);
        isFire = false;

    }
    public void OpenJournal()
    {
        inventoryBag.SetActive(false);
        journalOpen = true;
        journal.SetActive(true);
        
    }

    public void CloseJournal()
    {
        inventoryBag.SetActive(true);
        journalOpen = false;
        journal.SetActive(false);
    }
    
    void ActivateInventory()
    {
        if (inventoryOpen)
        {
            inventoryBag.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PM.enabled = false;
            ML.enabled = false;
        }

        else
        {
            inventoryBag.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PM.enabled = true;
            ML.enabled = true;
        }

    }

    public void FishingOutcome()
    {
        
        fishCaught = true;
        rodUsed = true;
        fishInventory.SetActive(true);
        AddToInventory(0);
        ObjectivesCompleted(5);
        if (!firstFishCaught)
        {
            firstFishCaught = true;
            fishingBadge.SetActive(true);
            fishEndBadge.SetActive(true);
            noFishBadge.SetActive(false);
            fishingBadgeAchievement.SetActive(true);
        }
        
    }


    public void AddToInventory(int index)
    {
        //set image source to index
        BagGlow.SetActive(true);
        addingIcon.sprite = addingImages[index];
        movingToBag.SetActive(true);
        //textBackground.SetActive(true);

        switch (index)
        {
            case 0:
                bagUpdates.text = "Fish caught!";
                break;

            case 1:
                bagUpdates.text = "Axe added to inventory";
                break;

            case 2:
                if (axeActive)
                {
                    bagUpdates.text = "+5 wood";
                }

                else
                {
                    bagUpdates.text = "+1 wood";
                }
                
                break;

            case 3:
                bagUpdates.text = "+1 manchineel";
                break;

            case 4:
                bagUpdates.text = "+1 plum";
                break;

            case 5:
                bagUpdates.text = "+1 apple";
                break;

            case 6:
                bagUpdates.text = "Flask full";
                break;

            case 7:
                bagUpdates.text = "Ginger collected";
                break;

            case 8:
                bagUpdates.text = "Aloe collected";
                break;

            default: bagUpdates.text = " ";
                break;
        }
        //if index equals etc (use cases) bagUpdates.text = ...


        StartCoroutine(DeactivateMovingIcon());
    }

    IEnumerator DeactivateMovingIcon()
    {
        yield return new WaitForSeconds(1);
        movingToBag.SetActive(false);

        yield return new WaitForSeconds(3);
        bagUpdates.text = " ";
        //textBackground.SetActive(false);
    }

    public void CloseInventory()
    {
        Debug.Log("This fn works");
        inventoryOpen = false;
        ActivateInventory();
    }

    public void AloeCollection()
    {
        Debug.Log("Aloe collected");
        collectAloeEnabled = false;
        foreach (GameObject ui in aloeUI)
        {
            ui.SetActive(true);
        }
        
        aloeInventory.SetActive(true);
        aloeCollected = true;
        AddToInventory(8);

        if (!firstAloe)
        {
            newPlantInfo.SetActive(true);
            firstAloe = true;
            StartCoroutine(DeactivateNewInfo());
        }

        //UI text saying new plant found! or aloe collected
    }

    public void GingerCollection()
    {
        Debug.Log("Ginger collected");
        collectGingerEnabled = false;
        foreach (GameObject ui in gingerUI)
        {
            ui.SetActive(true);
        }

        gingerInventory.SetActive(true);
        gingerCollected = true;
        AddToInventory(7);

        if (!firstGinger)
        {
            newPlantInfo.SetActive(true);
            firstGinger = true;
            StartCoroutine(DeactivateNewInfo());
        }
    }

    public void CollectWater()  //activated when clicking collect water button
    {
        collectWaterEnabled = false;
        

        collectingWater.SetActive(true);  //activate collecting water UI or animation

        controller.enabled = false; //deactivate character controller

        StartCoroutine(WaterCollection());
    }

    IEnumerator WaterCollection()
    {
        yield return new WaitForSeconds(4);
        //update water collected amount
        waterCollected = true; //need this to activate treat water task
        dirtyWater.SetActive(true);
        cleanWater.SetActive(false);
        Purif.StartPurification();
        AddToInventory(6);
        collectingWater.SetActive(false);  //deactivate collecting UI
        WaterSound.SetActive(false);
        controller.enabled = true; //Reactivate character controller
        waterScript.timePassed = 0;

    }

    public void CollectApple()
    {
        collectAppleEnabled = false;
        //picking apple sound
        //appleCollected = true;
        AddToInventory(5);
        appleInventory.SetActive(true);
        numberOfApples++;
        //ui text display to indicate collected
        Debug.Log("apple collected");
        foreach (GameObject ui in journalApple)
        {
            ui.SetActive(true);
        }

        if (!firstApple)
        {
            newPlantInfo.SetActive(true);
            firstApple = true;
            StartCoroutine(DeactivateNewInfo());
        }
    }

    public void CollectPlum()
    {
        collectPlumEnabled = false;
        //picking fruit sound
        //plumCollected = true;
        AddToInventory(4);
        plumInventory.SetActive(true);
        numberOfPlums++;
        //ui text display to indicate collected
        Debug.Log("plum collected");
        foreach (GameObject ui in journalPlum)
        {
            ui.SetActive(true);
        }

        if (!firstPlum)
        {
            newPlantInfo.SetActive(true);
            firstPlum = true;
            StartCoroutine(DeactivateNewInfo());
        }
    }

    public void CollectMango()
    {
        collectMangoEnabled = false;
        //picking fruit sound
        //mangoCollected = true;
        AddToInventory(3);
        mangoInventory.SetActive(true);
        numberOfMangos++;
        //ui text display to indicate collected
        Debug.Log("mango collected");
        foreach (GameObject ui in journalMango)
        {
            ui.SetActive(true);
        }

        if (!firstMango)
        {
            newPlantInfo.SetActive(true);
            firstMango = true;
            StartCoroutine(DeactivateNewInfo());
        }
    }

    public IEnumerator DeactivateNewInfo()
    {
        if (firstAloe && firstGinger && firstMango && firstPlum && firstApple)
        {
            floraBadge.SetActive(true);
            noFloraBadge.SetActive(false);
            floraEndBadge.SetActive(true);
            floraBadgeAchievement.SetActive(true);
        }
        yield return new WaitForSeconds(4);
        newPlantInfo.SetActive(false);
        
        //floraBadgeAchievement.SetActive(false);
    }

    public void CollectWood()  //activated when clicking collect wood button
    {
        woodScript.timePassed = 0;
        collectWoodEnabled = false;
        

        collectingWood.SetActive(true); //activate collecting wood UI or animation
        
        controller.enabled = false; //deactivate character controller

        StartCoroutine(WoodCollection());
    }

    IEnumerator WoodCollection()
    {
        yield return new WaitForSeconds(4);
        //update wood collected amount
        woodCollected = true; //need this to activate fire task
        AddToInventory(2);

        if (!axeActive)
        {
           
            numberOfLogs++;
            
        }

        else
        {
            axeUsed = true;
            if (numberOfLogs <= 10)
            {
                numberOfLogs += 5;
            }

            else 
            {
                numberOfLogs = 15;
            }

            
        }
        
        numberOfLogsUI.text = numberOfLogs.ToString() + "/15";
        collectingWood.SetActive(false);//deactivate collecting UI
        
        controller.enabled = true; //Reactivate character controller
        woodScript.timePassed = 0;

    }

    public void StorageFull()
    {
        storageFullUI.SetActive(true);
        collectAloeEnabled = false;
        collectAppleEnabled = false;
        collectGingerEnabled = false;
        collectMangoEnabled = false;
        collectPlumEnabled = false;
        collectWaterEnabled = false;
        collectWoodEnabled = false;

        StartCoroutine(DeactivateSFUI());
    }

    IEnumerator DeactivateSFUI()
    {
        yield return new WaitForSeconds(2);
        storageFullUI.SetActive(false);
    }
    public void ActivateChemSet()
    {
        
            if (chemSetOpen)
            {
                chemistrySet.SetActive(false);
                controller.enabled = true;
                chemSetOpen = false;
                if (!inventoryOpen)
            {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    PM.enabled = true;
                    ML.enabled = true;
            }
                
        }

            else
            {
                chemistrySet.SetActive(true);
                controller.enabled = false;
                chemSetOpen = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                PM.enabled = false;
                ML.enabled = false;
        }


        CloseInventory();
            
        
    }

    public void AxeCollection()
    {
        if (axeSeen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(axe1);
                axe2.SetActive(true);
                axeActive = true;
                axeCollected = true;
                axeInventory.SetActive(true);
                AddToInventory(1);
                //axeInBag.SetActive(true);
                StartCoroutine(AxeNotSeen());
                
                //activate axe in inventory
                //UI to say press A to pack axe or activate axe etc
            }
        }
    }

    IEnumerator AxeNotSeen()
    {
        yield return new WaitForSeconds(0.5f);
        axeSeen = false;
        yield return new WaitForSeconds(2f);
        //axeInBag.SetActive(false);
    }

    public void ActivateAxe()
    {
        if (axeCollected)
        {
            if (axeActive)
            {
                axe2.SetActive(false);
                axeActive = false;
            }

            else
            {
                axe2.SetActive(true);
                axeActive = true;
            }
            
            CloseInventory();
        }
    }

    public void ActivateBinocs()
    {
        if (binocsActive)
        {
            binocsActive = false;
            binocUI.SetActive(false);
            cam.fieldOfView = 60;
        }

        else
        {
            binocsActive = true;
            binocUI.SetActive(true);
            cam.fieldOfView = 40;
        }

        CloseInventory();
    }

    public void ObjectivesCompleted(int number)
    {
        if (!firstTime[number])
        {
            //UI or audio for objective complete
            firstTime[number] = true;
            completeObjectiveTick[number].SetActive(true);
            objectivesTicked++;

            if (objectivesTicked >= 9)
            {
                objectivesBadge.SetActive(true);
                noObjectivesBadge.SetActive(false);
                objectivesEndBadge.SetActive(true);
                //objectivesBadgeAchievement.SetActive(true);
                WinCondition();
            }
        }

        
    }

    public void EatGinger()
    {
        eatGingerPrompt.SetActive(false);
        //isEating = true;
        CloseInventory();
        controller.enabled = false;
        eatingGingerUI.SetActive(true);
        gingerCollected = false;
        gingerInventory.SetActive(false);
        //eating sound

        if (isPoisoned)
        {
            isHealing = true;
        }
        StartCoroutine(StopEatingGinger());

    }

    IEnumerator StopEatingGinger()
    {
        yield return new WaitForSeconds(2);
        //isEating = false;
        isHealing = false;
        isPoisoned = false;
        controller.enabled = true;
        eatingGingerUI.SetActive(false);
        
    }

    public void EatAloe()
    {
        eatAloePrompt.SetActive(false);
        //isEating = true;
        CloseInventory();
        controller.enabled = false;
        eatingAloeUI.SetActive(true);
        aloeCollected = false;
        aloeInventory.SetActive(false);
        //eating sound

        if (isBurnt)
        {
            isHealing = true;
        }
        StartCoroutine(StopEatingAloe());

    }

    IEnumerator StopEatingAloe()
    {
        yield return new WaitForSeconds(2);
        //isEating = false;
        isHealing = false;
        isBurnt = false;
        controller.enabled = true;
        eatingAloeUI.SetActive(false);

    }

    public void EatApple()
    {
        eatApplePrompt.SetActive(false);
        isEating = true;
        CloseInventory();
        controller.enabled = false;
        eatingAppleUI.SetActive(true);
        numberOfApples--;
        //eating sound
        StartCoroutine(StopEatingApple());
        
        

    }


    IEnumerator StopEatingApple()
    {
        yield return new WaitForSeconds(2);
        isEating = false;
        controller.enabled = true;
        eatingAppleUI.SetActive(false);
    }
    public void EatPlum()
    {
        eatPlumPrompt.SetActive(false);
        isEating = true;
        CloseInventory();
        controller.enabled = false;
        eatingPlumUI.SetActive(true);
        numberOfPlums--;
        //eating sound
        StartCoroutine(StopEatingPlum());

        

    }


    IEnumerator StopEatingPlum()
    {
        yield return new WaitForSeconds(2);
        isEating = false;
        controller.enabled = true;
        eatingPlumUI.SetActive(false);
    }
    public void EatMango()
    {
        eatMangoPrompt.SetActive(false);
        CloseInventory();
        isEatingMango = true;
        controller.enabled = false;
        eatingMangoUI.SetActive(true);
        numberOfMangos--;
        //eating sound
        StartCoroutine(StopEatingMango());

        

    }

    public void EatRawFish()
    {
        rawFishPrompt.SetActive(false);
        CloseInventory();
        isEatingMango = true;
        controller.enabled = false;
        eatingFishUI.SetActive(true);
        fishCaught = false;
        fishInventory.SetActive(false);
        fishInvClicked = false;
        StartCoroutine(StopEatingRawFish());

    }

    IEnumerator StopEatingRawFish()
    {
        yield return new WaitForSeconds(1);
        isEatingMango = false;
        controller.enabled = true;
        eatingFishUI.SetActive(false);
        rawFishDangerInfo.SetActive(true);
        isPoisoned = true;
        dangerUI.SetActive(true);

        yield return new WaitForSeconds(3);
        rawFishDangerInfo.SetActive(false);
        dangerUI.SetActive(false);
    }

    IEnumerator StopEatingMango()
    {
        yield return new WaitForSeconds(1);
        isEatingMango = false;
        controller.enabled = true;
        eatingMangoUI.SetActive(false);
        mangoDangerInfo.SetActive(true);
        isPoisoned = true;
        dangerUI.SetActive(true); 

        yield return new WaitForSeconds(3);
        mangoDangerInfo.SetActive(false);
        dangerUI.SetActive(false);
    }

    public void FireBurn()
    {
        isBurnt = true;
        isBurning = true;
        dangerUI.SetActive(true);
        isBurningInfo.SetActive(true);
        StartCoroutine(StopBurning());
        
    }

    IEnumerator StopBurning()
    {
        yield return new WaitForSeconds(1);
        isBurning = false;

        yield return new WaitForSeconds(3);
        isBurningInfo.SetActive(false);
        dangerUI.SetActive(false);
    }

    public void LoseCondition()
    {
        gamePaused = true;
        Time.timeScale = 0;
        lostUI.SetActive(true);
        badgesEnd.SetActive(true);
    }

    public void WinCondition()
    {
        gamePaused = true;
        Time.timeScale = 0;
        winUI.SetActive(true);
        badgesEnd.SetActive(true);
    }
}
