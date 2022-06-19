using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Converter : MonoBehaviour
{
    public GameObject gold;
    public GameObject diaomond;
    private Vector3 destroyObjectPosition;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            other.gameObject.GetComponent<MeshFilter>().sharedMesh =
                gold.gameObject.GetComponent<MeshFilter>().sharedMesh;
            other.gameObject.GetComponent<Transform>().localScale = Vector3.one;
            Destroy(other.gameObject.GetComponent<BoxCollider>());
            other.gameObject.AddComponent<BoxCollider>();
            StartCoroutine(GoldConverterAnim(other.gameObject));
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            other.gameObject.GetComponent<MeshFilter>().sharedMesh =
                diaomond.gameObject.GetComponent<MeshFilter>().sharedMesh;
            other.gameObject.GetComponent<Transform>().localScale = Vector3.one;
            Destroy(other.gameObject.GetComponent<BoxCollider>());
            other.gameObject.AddComponent<BoxCollider>();

            StartCoroutine(DiamondConverterAnim(other.gameObject));
        }
    }


    private IEnumerator GoldConverterAnim(GameObject game)
    {
        yield return new WaitForSeconds(1);

        game.gameObject.tag = "Gold";
        GameManager.instance.MoneyCounter();
        GameManager.instance.ParaSayisiTextChange();
    }

    private IEnumerator DiamondConverterAnim(GameObject game)
    {
        yield return new WaitForSeconds(1);

        game.gameObject.tag = "Diamond";
        GameManager.instance.MoneyCounter();
        GameManager.instance.ParaSayisiTextChange();
    }
}