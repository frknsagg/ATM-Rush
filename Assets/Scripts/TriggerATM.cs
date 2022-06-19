using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TriggerATM : MonoBehaviour
{
    private TextMeshProUGUI _atmMoney;
    private Animation _anim;


    private void Start()
    {
        _atmMoney = GameObject.Find("atc").GetComponent<TextMeshProUGUI>();
        _atmMoney.text = "" + GameManager.instance.atmParaSayisi;
        _anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Money":
                GameManager.instance.atmParaSayisi += 1;
                Destroy(other.gameObject);
                GameManager.instance.collectedItems.Remove(other.gameObject);
                _atmMoney.text = "" + GameManager.instance.atmParaSayisi;
                break;
            case "Gold":
                GameManager.instance.atmParaSayisi += 2;
                Destroy(other.gameObject);
                GameManager.instance.collectedItems.Remove(other.gameObject);
                _atmMoney.text = "" + GameManager.instance.atmParaSayisi;
                break;
            case "Diamond":
                GameManager.instance.atmParaSayisi += 4;
                Destroy(other.gameObject);
                GameManager.instance.collectedItems.Remove(other.gameObject);
                _atmMoney.text = "" + GameManager.instance.atmParaSayisi;
                break;
            case "Player":
                _anim.Play();
                break;
        }
    }
}