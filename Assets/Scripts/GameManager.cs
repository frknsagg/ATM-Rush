using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>();


    public int atmParaSayisi = 0;

    TextMeshProUGUI _paraSayisiText;
    public TextMeshProUGUI levelText;


    public GameObject karakter;
    public static GameManager instance;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        _paraSayisiText = GameObject.Find("ParaSayisi").GetComponent<TextMeshProUGUI>();

        collectedItems.Add(karakter);
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    public void AddCollected(GameObject gameobject)
    {
        collectedItems.Add(gameobject);
    }

    public void TailMovement()
    {
        for (int i = 1; i < collectedItems.Count; i++)
        {
            collectedItems[i].GetComponent<NodeMovement>().connectedNode =
                collectedItems[i - 1].GetComponent<Transform>();
        }
    }

    public void ParaSayisiTextChange()
    {
        _paraSayisiText.text = "" + (MoneyCounter() + atmParaSayisi);
    }

    private void SaveTheLevel()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex + 1;

        PlayerPrefs.SetInt("level", activeScene);
        PlayerPrefs.SetInt("totalMoney", (atmParaSayisi + MoneyCounter()));
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishLevel()
    {
        SaveTheLevel();

        animator.SetBool("GameFinished", true);

        SceneManager.LoadScene(0);
    }

    public int MoneyCounter()
    {
        int moneyCounter = 0;
        for (int i = 1; i < collectedItems.Count; i++)
        {
            switch (collectedItems[i].gameObject.tag)
            {
                case "Money":
                    moneyCounter += 1;
                    break;
                case "Gold":
                    moneyCounter += 2;
                    break;
                case "Diamond":
                    moneyCounter += 4;
                    break;
                default:
                    moneyCounter += 0;
                    break;
            }
        }

        return moneyCounter;
    }
}