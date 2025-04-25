using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiateTrigger : MonoBehaviour
{

private void OnTriggerEnter(Collider initia) {
    
     if (initia.gameObject.tag == "Player")
    {
        Debug.Log("Placeholer next level");
        StartCoroutine("Advance");
    }
}       

    IEnumerator Advance()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("advancement working");
        gameObject.transform.parent.position = new Vector3( 0, 0, gameObject.transform.parent.position.z + 200);


    }   

    }
