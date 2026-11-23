using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        while (true)
        {
            Debug.Log($"当前帧为{Time.frameCount},当前时间{Time.realtimeSinceStartup}");
             yield return null;
        }
        
    }
}
