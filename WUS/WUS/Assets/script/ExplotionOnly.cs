using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionOnly : MonoBehaviour
{
    public GameObject ExploadObj;
    public GameObject ExploadPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);
    }
}
