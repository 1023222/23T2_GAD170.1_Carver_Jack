using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Don't press the spacebar...");
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown("z"))
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Stop that, you egg.");
        }
    }
}
