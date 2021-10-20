using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CharacterStatusData playerStatusData;
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float jumpValue = 10f;
        [SerializeField] private int firstJumpStaminaCost = 10;
        [SerializeField] private int secondJumpStaminaCost = 15;
        [SerializeField] private float dashMultiplier = 2f;
        [SerializeField] private float cooldownTime = 1.5f;
        [SerializeField] private float dashDuration = 0.5f;
        [SerializeField] private int dashStaminaCost = 25;
        [SerializeField] private float distToGround = 1.05f;
        [SerializeField] private float gravity = 9.81f;

        private PlayerInputAsset playerInputAsset;
        private CharacterController charController;
        private Vector2 inputValue;
        private float yVelocity;
        private bool canDash = true;
        private enum JumpState {HaveNotJumped, JumpedOnce, JumpedTwice}
        JumpState jumpState;

        public delegate void Stamina(int staminaCost);
        public static event Stamina SetStamina;

        private void Awake()
        {
            charController = GetComponent<CharacterController>();
            playerInputAsset = new PlayerInputAsset();
        }

        private void Start()
        {
            jumpState = JumpState.HaveNotJumped;
        }

        private void OnEnable()
        {
            playerInputAsset.Standing.Enable();
            playerInputAsset.Standing.Jump.performed += Jump_performed;
            playerInputAsset.Standing.Movement.performed += Movement_performed;
            playerInputAsset.Standing.Movement.canceled += Movement_canceled;
            playerInputAsset.Standing.Dash.performed += Dash_performed;
        }

        private void OnDisable()
        {
            playerInputAsset.Standing.Disable();
            playerInputAsset.Standing.Jump.performed -= Jump_performed;
            playerInputAsset.Standing.Movement.performed -= Movement_performed;
            playerInputAsset.Standing.Movement.canceled -= Movement_canceled;
            playerInputAsset.Standing.Dash.performed -= Dash_performed;
        }

        void FixedUpdate()
        {
            Debug.Log(Physics.Raycast(transform.position, Vector3.down, distToGround));

            if (Physics.Raycast(transform.position, Vector3.down, distToGround))
            {
                if (yVelocity < -0.2f) // todo fix yVelocity stick in -0.1 and -0.29, make it 0 when on ground
                    yVelocity += gravity * Time.deltaTime;
                else
                    yVelocity -= gravity * Time.deltaTime;
            }
            else
            {
                yVelocity -= gravity * Time.deltaTime;
            }
            Debug.Log(yVelocity);
            MovePlayer(inputValue);
        }


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (Physics.Raycast(transform.position, Vector3.down, distToGround))
                jumpState = JumpState.HaveNotJumped;
        }

        private void Jump_performed(InputAction.CallbackContext obj)
        {
            switch (jumpState) // 0-1-2 = jumped this number of times
            {
                case (JumpState)0:
                    if (playerStatusData.stamina >= firstJumpStaminaCost)
                    {
                        DoJump(1, firstJumpStaminaCost);
                    }
                    return;
                case (JumpState)1:
                    if (playerStatusData.stamina >= secondJumpStaminaCost)
                    {
                        DoJump(2, secondJumpStaminaCost);
                    }
                    return;
                default:
                    Debug.LogError("jumpState Error");
                    return;
            }
        }

        private void DoJump(int jumpStateNumber, int jumpStaminaCost)
        {
            jumpState = (JumpState)jumpStateNumber;
            SetStamina?.Invoke(jumpStaminaCost);
            yVelocity = 0;
            yVelocity += jumpValue;
        }

        private void Movement_performed(InputAction.CallbackContext obj)
        {
            inputValue = obj.ReadValue<Vector2>();
        }

        private void MovePlayer(Vector2 inputValue)
        {
            Vector3 direction = new Vector3(inputValue.x, yVelocity / movementSpeed, inputValue.y);
            Vector3 distance = direction * movementSpeed * Time.deltaTime;
            charController.Move(distance);
        }

        private void Movement_canceled(InputAction.CallbackContext obj)
        {
            inputValue = new Vector2(0f, 0f);
        }

        private void Dash_performed(InputAction.CallbackContext obj)
        {
            if (canDash && playerStatusData.stamina >= dashStaminaCost)
            {
                canDash = false;
                StartCoroutine(PerformDash());
                if (SetStamina != null)
                    SetStamina(dashStaminaCost);
            }
        }

        private IEnumerator PerformDash()
        {
            // This will wait 1 second like Invoke could do, remove this if you don't need it
            //yield return new WaitForSeconds(1);
            float timePassed = 0;

            movementSpeed *= dashMultiplier; // dash
            while (timePassed < dashDuration)
            {
                timePassed += Time.deltaTime;
                yield return null; // will wait until the next frame and then continue execution. Without it, it will execute the whoel while loop in one frame.
            }
            movementSpeed /= dashMultiplier;

            while (timePassed < cooldownTime)
            {
                timePassed += Time.deltaTime;
                yield return null;
            }
            canDash = true;
        }
    }
}
