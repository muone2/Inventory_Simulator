using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody p_rigid;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Inventory inventory;
    [SerializeField] UIManager uiManager;

    [SerializeField] float maxDistanceToTargetObj = 10f;
    [SerializeField] float CheckOnGroundRayLength = 0.6f; //1*1*1큐브 기준

    [SerializeField] Vector3 playerFrontVec;
    [SerializeField] GameObject targetObj;
    [SerializeField] Vector3 hitPoint;
    [SerializeField] float distanceToTargetHitPoint;

    private void Update()
    {
        Debug.DrawRay(player.transform.position, Vector3.down * CheckOnGroundRayLength, Color.red);
        //아래로 쏘는 디버그용 레이. 땅에 아슬하게 닿는 길이를 시각적으로 확인하기 위함

        CheckPlayerFront();
    }

    public void JumpPlayer()
    {
        CheckOnGroundAndJump();
    }
    public void WalkPlayer(float vertical)
    {
        WalkFront(vertical);
    }
    public void TurnPlayer(float horizontal)
    {
        TurnSide(horizontal);
    }
    public void SetTarget(RaycastHit hit)
    {
        SetTargetObjInfo(hit);
    }

    private void CheckPlayerFront()
    {
        playerFrontVec = player.transform.forward;
    }

    private void WalkFront(float vertical)
    {
        playerMovement.Walk(playerFrontVec, vertical, p_rigid);
    }
    private void TurnSide(float horizontal)
    {
        playerMovement.Turn(horizontal, p_rigid);
    }
    private void CheckOnGroundAndJump()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, CheckOnGroundRayLength))
        {
            //   Debug.Log(hit.collider.name);
            playerMovement.Jump(p_rigid);
        }
    }
    private void SetTargetObjInfo(RaycastHit hit)
    {
        if (hit.collider != null)
        {
            hitPoint = hit.point;
            distanceToTargetHitPoint = (hitPoint - player.transform.position).magnitude;

            if (maxDistanceToTargetObj > distanceToTargetHitPoint)
                targetObj = hit.collider.gameObject;
            else
                targetObj = null;
        }
        else
        {
            distanceToTargetHitPoint = -1;
            targetObj = null;
        }

        if(targetObj != null)
            uiManager.ShowItemName(targetObj.name, hitPoint);
        else
            uiManager.ShowItemNameNull();
    }
}
