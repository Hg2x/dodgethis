using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] CharacterStatusData playerStatusData;
    [SerializeField] Slider healthBar;

    private void OnEnable()
    {
        Player.PlayerStatusHandler.SetHealth += SetHealthBar;
    }

    private void OnDisable()
    {
        Player.PlayerStatusHandler.SetHealth -= SetHealthBar;
    }

    private void Awake()
    {
        healthBar = GetComponent<Slider>();
    }
    private void Start()
    {
        healthBar.maxValue = playerStatusData.maxHealth;
        SetHealthBar();
    }

    private void SetHealthBar()
    {
        healthBar.value = playerStatusData.health;
    }
}
