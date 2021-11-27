using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameManager GM;

    public float speed = 4;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 move;
    Vector3 velocity;
    public bool isGrounded;

    public float bobSpeed;
    public float bobAmount;
    float defaultYPos;
    float timer;

    private void Start()
    {
        defaultYPos = GM.cam.transform.localPosition.y;
    }

    void Update()
    {
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        bobSpeed = speed * 2.5f;
        bobAmount = speed * 0.05f;
        HeadBob();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
            GM.energyDecrease = 2.5f;
        }
        else
        {
            speed = 4;
            GM.energyDecrease = 4;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }*/

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void HeadBob()
    {
        if (Mathf.Abs(move.x) > 0.1f || Mathf.Abs(move.z) > 0.1f)
        {
            Debug.Log("This shit works apparently");
            timer += Time.deltaTime * bobSpeed;
            GM.cam.transform.localPosition = new Vector3(GM.cam.transform.localPosition.x, defaultYPos + Mathf.Sin(timer) * bobAmount, GM.cam.transform.localPosition.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Log")
        {
            GM.LogEnabled = true;
        }
        if (other.gameObject.tag == "Water")
        {
            GM.collectWaterEnabled = true;
        }

        if (other.gameObject.tag == "Wood")
        {
            GM.collectWoodEnabled = true;
        }

        if (other.gameObject.tag == "FishingSpot")
        {
            GM.startFishingEnabled = true;
            Debug.Log("Fishing spot");
        }

        if (other.gameObject.tag == "Fireplace")
        {
            if (GM.hasWood) //but not logs in place
            {
                GM.startFireEnabled = true;
                GM.ObjectivesCompleted(0);
            }
        }

        if (other.gameObject.tag == "aloePlant")
        {
            GM.collectAloeEnabled = true;
        }

        if (other.gameObject.tag == "gingerPlant")
        {
            GM.collectGingerEnabled = true;
        }

        

        if (other.gameObject.tag == "Axe")
        {
            GM.axeSeen = true;
        }

        if (other.gameObject.tag == "PlumTree")
        {
            GM.collectPlumEnabled = true;
        }

        if (other.gameObject.tag == "AppleTree")
        {
            GM.collectAppleEnabled = true;
        }

        if (other.gameObject.tag == "MangoTree")
        {
            GM.collectMangoEnabled = true;
        }

        if (other.gameObject.tag == "ChemArea")
        {
            GM.activateChemSet = true;
        }

        if (other.gameObject.tag == "fire")
        {
            GM.FireBurn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            GM.collectWaterEnabled = false;
        }

        if (other.gameObject.tag == "Wood")
        {
            GM.collectWoodEnabled = false;
        }

        if (other.gameObject.tag == "FishingSpot")
        {
            GM.startFishingEnabled = false;
        }

        if (other.gameObject.tag == "Fireplace")
        {
       
            GM.startFireEnabled = false;
       
        }

        if (other.gameObject.tag == "aloePlant")
        {
            GM.collectAloeEnabled = false;
        }

        if (other.gameObject.tag == "gingerPlant")
        {
            GM.collectGingerEnabled = false;
        }

        if (other.gameObject.tag == "Axe")
        {
            GM.axeSeen = false;
        }

        if (other.gameObject.tag == "PlumTree")
        {
            GM.collectPlumEnabled = false;
        }

        if (other.gameObject.tag == "AppleTree")
        {
            GM.collectAppleEnabled = false;
        }

        if (other.gameObject.tag == "MangoTree")
        {
            GM.collectMangoEnabled = false;
        }

        if (other.gameObject.tag == "ChemArea")
        {
            GM.activateChemSet = false;
        }
        if (other.gameObject.tag == "Log")
        {
            GM.LogEnabled = false;
        }
    }

   

    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "aloePlant")
        {
            GM.AloeCollection();
        }

        if (collision.gameObject.tag == "gingerPlant")
        {
            GM.GingerCollection();
        }


    }*/
}