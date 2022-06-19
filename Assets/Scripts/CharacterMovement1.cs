using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterMovement1 : MonoBehaviour
{
    private float _horizontalValue;

    private void FixedUpdate()
    {
#if UNITY_ANDROID
        if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            horizontalValue = Input.GetTouch(0).deltaPosition.x * 0.5f;
            horizontalValue = Mathf.Clamp(horizontalValue, -2.3f, 2.3f);

            transform.position = new Vector3(horizontalValue, transform.position.y, this.transform.position.z);
        }


#elif UNITY_EDITOR

        _horizontalValue += Input.GetAxis("Horizontal") * 0.5f;
        _horizontalValue = Mathf.Clamp(_horizontalValue, -2.3f, 2.3f); // Karakterin x ekseninde hareketini sınırlamak için yazılan kod


        transform.position = new Vector3(_horizontalValue, transform.position.y, transform.position.z);


#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.FinishLevel();
        }
    }
}