using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private Rigidbody _physic;

    private void Start()
    {
        _physic = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            AddPropertyToGameObject(other.gameObject);
        }

        if (other.gameObject.CompareTag(("Gold")))
        {
            AddPropertyToGameObject(other.gameObject);
        }

        if (other.gameObject.CompareTag(("Diamond")))
        {
            AddPropertyToGameObject(other.gameObject);
        }

        if (other.gameObject.CompareTag("Conveynor"))
        {
            Destroy(this.gameObject.GetComponent<NodeMovement>());

            _physic.velocity = new Vector3(-10, 0, 0);
            GameManager.instance.collectedItems.Remove(this.gameObject);
        }

        if (other.gameObject.CompareTag("FinishBox"))
        {
            Destroy(gameObject);
        }
    }

    private void AddPropertyToGameObject(GameObject obje)
    {
        obje.AddComponent<CollectController>();
        obje.GetComponent<BoxCollider>().isTrigger = false;
        obje.AddComponent<NodeMovement>();
        obje.GetComponent<NodeMovement>().connectedNode =
            GameManager.instance.collectedItems.Last().GetComponent<Transform>();

        GameManager.instance.AddCollected(obje);
        GameManager.instance.ParaSayisiTextChange();
    }
}