using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody p_rigid;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Inventory inventory;

    [SerializeField] InputChecker inputChecker;
    [SerializeField] float maxDistanceToTargetObj = 10f;


    [SerializeField] Vector3 playerFrontVec;
    [SerializeField] float distanceToTargetHitPoint;
    [SerializeField] Vector3 hitPoint;
    [SerializeField] GameObject targetObj;

    private void Update()
    {
        CheckPlayerFront();
        SeeItemGet();
        SetTargetObjInfo();
    }

    public Vector3 GetTargethitPoint()
    {
        return hitPoint;
    }

    public GameObject GetTargetObj()
    {
        return targetObj;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckPlayerFront()
    {
        playerFrontVec = player.transform.forward;
    }

    private void MovePlayer()
    {
        playerMovement.CallMove(playerFrontVec, inputChecker.GetVertical(), inputChecker.GetHorizontal(), p_rigid);
    }

    private void SeeItemGet()//아이템 연출을 보면서 멈추게 할 생각이고, 지금은 멈추는 것만 됨
    {
        if (inputChecker.GetJump() >= 0.1f)
            playerMovement.changeMoveBool(false);
        else
            playerMovement.changeMoveBool(true);
    }

    private void SetTargetObjInfo()
    {
        RaycastHit hit = inputChecker.GetHitInfo();
        if (hit.collider != null)
            targetObj = hit.collider.gameObject; //없으면 null이다.
        else
            targetObj = null;

        if (targetObj != null)
        {
            hitPoint = hit.point;

            distanceToTargetHitPoint = (hitPoint - player.transform.position).magnitude;
            if (maxDistanceToTargetObj < distanceToTargetHitPoint)
            {
                distanceToTargetHitPoint = -1; //너무 멀리 있으면 없는 거 취급
                targetObj = null;
            }
        }
        else
            distanceToTargetHitPoint = -1; //거리가 음수일 수는 없다.
    }
}
