using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainActivationTriggers : MonoBehaviour
{
    public bool inRangeOfTerrain;
    public GameObject terrainPiece;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "firstTerrain")
        {
            inRangeOfTerrain = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRangeOfTerrain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRangeOfTerrain = false;
        }
    }
}
