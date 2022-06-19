using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _distance;
    public Transform characterTransform;

    private void Start()
    {
        _distance = transform.position - characterTransform.position;
    }


    private void Update()
    {
        transform.position =
            Vector3.Lerp(transform.position, characterTransform.position + _distance, Time.deltaTime * 5);
    }
}