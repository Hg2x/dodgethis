using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerStatusHandler : MonoBehaviour
    {
        [SerializeField] CharacterStatusData playerStatusData;  // insert in inspector
        [SerializeField] private int playerCurrentHealth; // show in inspector
        [SerializeField] private int playerCurrentStamina; // show in inspector
        [SerializeField] private int staminaIncreasePerTick = 1;
        [Tooltip("In seconds")] [SerializeField] float staminaTickRate = 0.1f;

        public delegate void Health();
        public static event Health SetHealth;

        float counter = 0;
        private void Start()
        {
            ResetPlayerStatus();
            if (SetHealth != null)
                SetHealth();
        }

        private void Update()
        {
            UpdateStatusInInspector();
            counter += Time.deltaTime;
            if (counter >= staminaTickRate && playerStatusData.stamina < playerStatusData.maxStamina)
            {
                StaminaRegen();
                counter = 0;
            }
        }


        private void OnEnable()
        {
            PlayerMovement.SetStamina += Reduce_Stamina;
        }

        private void OnDisable()
        {
            PlayerMovement.SetStamina -= Reduce_Stamina;
        }

        private void OnParticleCollision(GameObject other)
        {
            playerStatusData.health--;
            if (SetHealth != null)
                SetHealth();
            Debug.Log("player hit");
            // todo implement new and better damage to health
            if (playerStatusData.health <= 0)
            {
                playerStatusData.aliveStatus = false;
                Debug.Log("player DEAD");
            }
        }

        private void ResetPlayerStatus()
        {
            playerStatusData.health = playerStatusData.maxHealth;
            playerStatusData.stamina = playerStatusData.maxStamina;
            playerStatusData.aliveStatus = true;
        }

        private void UpdateStatusInInspector()
        {
            playerCurrentHealth = playerStatusData.health;
            playerCurrentStamina = playerStatusData.stamina;
        }

        private void StaminaRegen()
        {
            playerStatusData.stamina += staminaIncreasePerTick;
        }

        private void Reduce_Stamina(int dashStaminaCost)
        {
            playerStatusData.stamina -= dashStaminaCost;
        }
    }
}
