using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    private Dropdown difficultyDropdown;
    private Slider musicSlider;
    private Slider sfxSlider;

    private void Awake()
    {
        difficultyDropdown = GameObject.Find("Difficulty Dropdown").GetComponent<Dropdown>();
        musicSlider = GameObject.Find("Music Slider").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();
    }
    private void Start()
    {
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty Dropdown");
        musicSlider.value = PlayerPrefs.GetInt("Music Volume");
        sfxSlider.value = PlayerPrefs.GetInt("SFX Volume");
    }

    public void OnDifficultyDropdownValueChange()
    {
        int index = difficultyDropdown.value; // 0 easy, 1 normal, 2 hard
        PlayerPrefs.SetInt("Difficulty Dropdown", index);
        Debug.Log(index);
    }

    public void OnMusicSliderValueChanged()
    {
        int newValue = (int) musicSlider.value;
        PlayerPrefs.SetInt("Music Volume", newValue);
    }

    public void OnSFXliderValueChanged()
    {
        int newValue = (int) sfxSlider.value;
        PlayerPrefs.SetInt("SFX Volume", newValue);
    }

    public void OnSettingsOKButtonClick()
    {
        settingsMenu.SetActive(false);
    }
}
