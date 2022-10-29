using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float turnSpeed = 5.0f;
    [SerializeField] bool moveBool = true;

    public void changeMoveBool(bool a)
    {
        moveBool = a;
    }

    public void CallMove(Vector3 front, float vertical, float horizontal, Rigidbody rigid) {
        if (moveBool == true) //이건 저쪽에서 봐야하지 않을까. 명령을 내렸지만 다리가 말을 안 듣는게 아니라, 명령을 애초에 안 내려야지.
        {
            Walk(front, vertical, rigid);
            Turn(horizontal);
        }
    }
    public void CallJump(Rigidbody rigid)
    {
        Jump(rigid);
    }

    private void Walk(Vector3 frontVec, float verticalValue, Rigidbody p_rigid)
    {
        Vector3 r = frontVec * verticalValue * moveSpeed;
        r.y = p_rigid.velocity.y;

        p_rigid.velocity = r;
    }

    private void Turn(float horizontalValue)
    {
        transform.Rotate(0, horizontalValue * turnSpeed, 0);
    }

    private void Jump(Rigidbody p_rigid)
    {
        Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(5f * -Physics.gravity.y);
        p_rigid.AddForce(jumpVelocity, ForceMode.Impulse);
    }
}
