using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] CharacterStatusData playerStatusData;
    [SerializeField] Slider staminaBar;

    private void Awake()
    {
        staminaBar = GetComponent<Slider>();
    }
    private void Start()
    {
        staminaBar.maxValue = playerStatusData.maxStamina;
        SetStaminaBar();
    }

    private void Update()
    {
        SetStaminaBar();
    }
    private void SetStaminaBar()
    {
        staminaBar.value = playerStatusData.stamina;
    }
}
