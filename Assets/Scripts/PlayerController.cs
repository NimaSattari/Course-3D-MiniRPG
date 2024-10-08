using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float rotateSpeed = 10;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] Animator animator;
    [SerializeField] Collider swordCollider;
    [SerializeField] float timeBetweenAttacks = 1f;

    private float timer;
    private bool isDead;

    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private void Awake()
    {
        GetComponent<PlayerHealth>().OnDie += Die;
    }

    void Update()
    {
        if (isDead) return;
        timer += Time.deltaTime;
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = moveSpeed * Input.GetAxis("Vertical");
        if( curSpeed >= 1f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        characterController.SimpleMove(forward * curSpeed);
        if(timer > timeBetweenAttacks)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack1");
                timer = 0f;
            }
            if (Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("Attack2");
                timer = 0f;
            }
        }

        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = -1.0f;
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime * 5;
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpHeight;
        }

        characterController.Move(playerVelocity * Time.deltaTime);
        if (Input.GetButtonDown("Esc"))
        {
            Loader.Instance.LoadMenu();
        }
    }

    public void Begin()
    {
        swordCollider.enabled = true;
    }

    public void End()
    {
        swordCollider.enabled = false;
    }


    private void Die()
    {
        isDead = true;
    }
}
