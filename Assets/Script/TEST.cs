using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Testing();
    }

    // Update is called once per frame
    public void Testing()
    {
        for (int i = 0; i < 3;)
        {
            Debug.Log(i);
        }
    }
}
