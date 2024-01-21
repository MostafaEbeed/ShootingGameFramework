using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] InputReader inputReader;
        [SerializeField] CharacterController characterController;
        [SerializeField] Animator animator;
        [SerializeField] float moveSpeed;
        [SerializeField] float gravityValue;
        [SerializeField] float controllerDeadZone = 0.1f;
        [SerializeField] float gamepadRotatingSmoothing = 1000f;

        [SerializeField] bool isGamepad;

        Vector2 moveDir;
        Vector2 animationMoveDir;
        Vector2 aimDir;
        Vector3 playerVelocity;

        float animationVelX;
        float animationVelZ;


        private void Update()
        {
            HandleInput();
            HandleMovement();
            HandleRotation();
        }

        void HandleInput()
        {
            moveDir = new Vector2(inputReader.MoveVector.x, inputReader.MoveVector.y).normalized;
            animationMoveDir = new Vector2(inputReader.MoveVector.x, inputReader.MoveVector.y);
            aimDir = new Vector2(inputReader.AimVector.x, inputReader.AimVector.y);
        }

        void HandleMovement()
        {
            Vector3 move = new Vector3(moveDir.x, 0, moveDir.y);
            characterController.Move(move * moveSpeed * Time.deltaTime);

            /*if(move.x > 0)
            {
                animationVelX += Time.deltaTime * 2f;
                if (animationVelX > 1) animationVelX = 1;
            }
            else
            {
                animationVelX -= Time.deltaTime * 2f;
                if (animationVelX < 0) animationVelX = 0;
            }

            if (move.y > 0)
            {
                animationVelZ += Time.deltaTime * 2f;
                if (animationVelZ > 1) animationVelZ = 1;
            }
            else
            {
                animationVelZ -= Time.deltaTime * 2f;
                if(animationVelZ < 0) animationVelZ = 0;
            } */

            //animationVelX = (float)(characterController.velocity.magnitude / moveSpeed);
            

            Debug.Log(aimDir.magnitude);

            playerVelocity.y += gravityValue * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);
        }

        void HandleRotation()
        {
            isGamepad = inputReader.isGamepad;

            if(isGamepad)
            {
                if(aimDir.magnitude > 0)
                {
                    if (Mathf.Abs(aimDir.x) > controllerDeadZone || Mathf.Abs(aimDir.y) > controllerDeadZone)
                    {
                        Vector3 playerDirection = Vector3.right * aimDir.x + Vector3.forward * aimDir.y;
                        if (playerDirection.sqrMagnitude > 0.0f)
                        {
                            animator.SetFloat("VerticalDir", moveDir.x);
                            animator.SetFloat("HorizontalDir", moveDir.y);

                            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, gamepadRotatingSmoothing * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    if (Mathf.Abs(moveDir.x) > controllerDeadZone || Mathf.Abs(moveDir.y) > controllerDeadZone)
                    {
                        Vector3 playerDirection = Vector3.right * moveDir.x + Vector3.forward * moveDir.y;
                        if (playerDirection.sqrMagnitude > 0.0f)
                        {
                            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, gamepadRotatingSmoothing * Time.deltaTime);
                        }
                    }
                } 
                
            }
        }
    }
}