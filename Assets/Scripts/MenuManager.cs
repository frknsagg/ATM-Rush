using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level") == 0 ? 1 : PlayerPrefs.GetInt("level"));
    }
}