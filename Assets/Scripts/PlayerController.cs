using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Collider swordCollider;
    CharacterController characterController;
    Animator animator;
    PlayerHealth playerHealth;

    bool isDead;
    Vector3 currentLookTarget = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.DieEvent += Die;
    }

    void Update()
    {
        if (isDead) return;
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveVector * 10);
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //float curSpeed = speed * Input.GetAxis("Vertical");
        //controller.SimpleMove(forward * curSpeed);
        if (moveVector.sqrMagnitude > 0.1f)
        {
            animator.SetBool("Walk", true);
        }
        else if(moveVector.sqrMagnitude <= 0.1f)
        {
            animator.SetBool("Walk", false);
        }
        if(Input.GetMouseButtonDown(0))
        {
            animator.Play("Attack1");
        }
        if(Input.GetMouseButtonDown(1))
        {
            animator.Play("Attack2");
        }
    }

    private void FixedUpdate()
    {
        if(isDead) return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
            }
            Vector3 targetPosiion = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosiion - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2.5f);

        }
    }

    private void Die()
    {
        isDead = true;
        animator.Play("Die");
    }

    public void Begin()
    {
        swordCollider.enabled = true;
    }

    public void End()
    {
        swordCollider.enabled = false;
    }
}
