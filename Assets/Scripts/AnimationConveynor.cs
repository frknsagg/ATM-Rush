using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConveynor : MonoBehaviour
{
    public GameObject[] animationSprite;
    private float _sayac = 0;


    private void LateUpdate()
    {
        _sayac += Time.deltaTime;
        if (!(_sayac > 0.2f)) return;
        animationSprite[0].GetComponent<SpriteRenderer>().flipY =
            !animationSprite[0].GetComponent<SpriteRenderer>().flipY;
        animationSprite[1].GetComponent<SpriteRenderer>().flipY =
            !animationSprite[1].GetComponent<SpriteRenderer>().flipY;
        _sayac = 0;
    }
}