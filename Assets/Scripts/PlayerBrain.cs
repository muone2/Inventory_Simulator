using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody p_rigid;
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] float vertical = 0.0f;
    [SerializeField] float horizontal = 0.0f;
    [SerializeField] float jump = 0.0f;

    [SerializeField] Vector3 playerFrontVec;


    private void Update()
    {
        CheckInput();
        CheckPlayerFront();
        SeeItemGet();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
    }

    private void CheckPlayerFront()
    {
        playerFrontVec = player.transform.forward;
    }

    private void MovePlayer()
    {
        playerMovement.CallMove(playerFrontVec, vertical, horizontal, p_rigid);
    }

    private void SeeItemGet()
    {
        if(jump>=0.5f)
            playerMovement.changeMoveBool(false);
        else
            playerMovement.changeMoveBool(true);
    }
}
