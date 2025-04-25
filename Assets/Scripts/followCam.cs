using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public float camSpeed;
    public float speedBoost;
    // Start is called before the first frame update
    void Start()
    {
          speedBoost = 4f;

    }

    // Update is called once per frame
    void Update()
    {

        if (speedBoost >= 0)
        {
            speedBoost -= Time.deltaTime;

        }
        if (speedBoost <= 0 && camSpeed < 50)
        {
            speedBoost = 4f;
            camSpeed++;
        }

        
        transform.Translate(Vector3.forward * camSpeed * Time.deltaTime);

       

    }
}
