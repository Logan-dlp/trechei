using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerController))]
public class JumpModule : MonoBehaviour
{
    [Header("Set Input")]
    [SerializeField, Space] KeyCode ToJump = KeyCode.Space;
    [Header("Set setting to jump")]
    [SerializeField] int CountJump = 1;
    [SerializeField] private float gravity = 3;
    [SerializeField, Space] float JumpForce = 1.5f;
    [Header("Player Components")]
    public Rigidbody Rb;
    [SerializeField] Collider colliders;
    [SerializeField] private PlayerController playerController;
    
    int count = 0;
    public bool isJumped = true;

    void JumpGavity()
    {
        if (isJumped == false)
        {
            Rb.AddForce(-transform.up * gravity);
        }
    }
    
    private void Start()
    {
        // Verify to colliders and Rigidbody
        if(colliders) return;
        Debug.LogError("Error Missing Collider !");
        if(Rb) return;
        Debug.LogError("Error Missing Rigidbody !");
    }
    private void Update()
    {
        JumpGavity();
        if (playerController.GameStart != true) return;
        if(Input.GetKeyDown(ToJump) && count <= CountJump)
        {
            // Add force for jump
            Rb.AddForce(transform.up * JumpForce);
            if (count == 1)
            {
                Rb.AddForce(transform.forward * JumpForce);
            }
            count++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Detection collision
        if(collision.gameObject.layer == LayerMask.NameToLayer("Sol"))
        {
            count = 0;
            isJumped = false;
        }
        else
        {
            isJumped = true;
        }
    }
}
