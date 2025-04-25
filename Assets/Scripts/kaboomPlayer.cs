using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaboomPlayer : MonoBehaviour
{
    public float initSpeed;
    private void OnTriggerEnter(Collider obj) {
        if (obj.gameObject.tag == "Foe")
        {
            Debug.Log("Destruction initiated");
            Destroy(obj.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initSpeed = 16;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * initSpeed * Time.deltaTime);
    }
}
