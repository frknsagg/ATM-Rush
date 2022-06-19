using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Money")
        {
            GameManager.instance.collectedItems.Remove(other.gameObject);
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            GameManager.instance.ParaSayisiTextChange();

        }
        if (other.gameObject.tag == "Gold")
        {
            GameManager.instance.collectedItems.Remove(other.gameObject);
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            GameManager.instance.ParaSayisiTextChange();

        }
        if (other.gameObject.tag == "Diamond")
        {
            GameManager.instance.collectedItems.Remove(other.gameObject);
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            GameManager.instance.ParaSayisiTextChange();

        }
    }
}
