using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptDeactivation : MonoBehaviour
{
    bool deactivate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate()
    {
        deactivate = true;
        yield return new WaitForSeconds(10);
        deactivate = false;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!deactivate)
        {
            StartCoroutine(Deactivate());
        }
    }
}
