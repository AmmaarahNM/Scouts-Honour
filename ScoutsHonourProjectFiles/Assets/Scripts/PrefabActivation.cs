using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabActivation : MonoBehaviour
{
    GameObject player;
    public bool activePrefab;
    //ublic GameObject[] scenePrefabs;
    public GameObject[] children;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject child in children)
        {
            child.SetActive(activePrefab);
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 55) //TEST THIS VALUE
        {
            activePrefab = false;
            
        }

        else
        {
            activePrefab = true;
        }

        
    }
}
