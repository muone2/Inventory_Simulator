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
    [SerializeField] float CheckOnGroundRayLength = 0.6f; //1*1*1ť�� ����

    [SerializeField] Vector3 playerFrontVec;
    [SerializeField] GameObject targetObj;
    [SerializeField] Vector3 hitPoint;
    [SerializeField] float distanceToTargetHitPoint;

    [SerializeField] bool playerState = true;

    private void Update()
    {
        Debug.DrawRay(player.transform.position, Vector3.down * CheckOnGroundRayLength, Color.red);
        //�Ʒ��� ��� ����׿� ����. ���� �ƽ��ϰ� ��� ���̸� �ð������� Ȯ���ϱ� ����

        CheckPlayerFront();
    }

    public void JumpPlayer()
    {
        if (playerState == true)
            CheckOnGroundAndJump();
    }
    public void WalkPlayer(float vertical)
    {
        if (playerState == true)
            WalkFront(vertical);
    }
    public void TurnPlayer(float horizontal)
    {
        if (playerState == true)
            TurnSide(horizontal);
    }
    public void SetTarget(RaycastHit hit)
    {
        if(playerState == true)
            SetTargetObjInfo(hit);
    }

    public void PlayerStop()
    {
        SetPlayerState(false);
        SetMoveStopAndTargetNull();
    }
    public void PlayerStopEnd()
    {
        SetPlayerState(true);
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
    private void SetPlayerState(bool OnOff)
    {
        if (OnOff == false)
            playerState = false;
        else
            playerState = true;
    }
    private void SetMoveStopAndTargetNull()
    {
        //�������� �������.
        //�̵� �ڵ忡�� ȣ����Ż�� ��Ƽ�� ���� 0���� �Ѱ��ָ� �����
        TurnSide(0);
        WalkFront(0);
        //�����ϴ� ���߿� ���ߴϱ� ���ڸ����� ���߰� �������� ���� �ھƿ�����, �̻��� ���°� �Ǿ���(...)

        uiManager.ShowItemNameNull();
    }
}
