using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    public void OnMainMenuPlayGameButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnMainMenuSettingsButtonClick()
    {
        settingsMenu.SetActive(true);
    }

    public void OnMainMenuExitButtonClick()
    {
        // exits game
    }
}
