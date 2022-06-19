using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public Transform connectedNode;

    private void LateUpdate()
    {
        if (connectedNode == null)
        {
            GameManager.instance.TailMovement();


            transform.position =
                new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 0.1f, Time.deltaTime * 7.5f), 2.15f,
                    connectedNode.position.z + 0.7f);
        }

        else
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 7.5f), 2.15f,
                connectedNode.position.z + 0.7f);
        }
    }
}