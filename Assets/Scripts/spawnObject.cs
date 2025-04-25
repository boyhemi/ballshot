using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
    public GameObject[] comboSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("initiateSpawn", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 50 * Time.deltaTime);
        
    }

    public void initiateSpawn()
    {

        Instantiate(comboSpawn[Random.Range(0,6)], new Vector3(Random.Range(-3.5f, 3.5f), transform.position.y, transform.position.z),Quaternion.identity);

    }
}
