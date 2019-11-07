using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControler : MonoBehaviour
{
  public Light myLight;

//Range Variable
public bool changeRange = false;
public float rangeSpeed = 1.0f;
public float maxRange = 10.0f;

    //intenstity Variable
public bool ChnageIntensity = false;
public float intensity = 1.0f;
public float intensitySpeed = 1.0f;
public float maxIntensity = 10.0f;

//Color Variable
public bool changeColors = false;
public float colorSpeed = 1.0f;
public Color startColor;
public Color endColor;

    float startTime;


    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeRange) 
        {
            myLight.range = Mathf.PingPong(Time.time * rangeSpeed, maxRange);
        }

        if (ChnageIntensity)
        {
            myLight.intensity = Mathf.PingPong(Time.time * intensitySpeed, maxIntensity);
        }
        if (changeColors)
        {
            float t = (Mathf.Sin(Time.time - startTime * colorSpeed));
            myLight.color = Color.Lerp(startColor, endColor, t);
        }




    }
}
