using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="money")
        {
            other.transform.SetParent(this.transform);
        }
        if (other.gameObject.tag=="Engel")
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,
                Mathf.Lerp(transform.position.z,transform.position.z-30f,0.2f));

            Debug.Log("çarptı");
        }
    }


   
}
