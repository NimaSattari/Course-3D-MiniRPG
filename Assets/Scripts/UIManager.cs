using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void LoadGame()
    {
        Loader.Instance.LoadGame();
    }

    public void LoadMenu()
    {
        Loader.Instance.LoadMenu();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
