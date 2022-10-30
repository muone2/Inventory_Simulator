using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float turnSpeed = 5.0f;
    [SerializeField] float JumpPower = 5.0f;

    public void Stop(Rigidbody rigid)
    {
        //만들 예정
    }

    public void Walk(Vector3 front, float vertical, Rigidbody rigid)
    {
        AddForceFront(front, vertical, rigid);
    }

    public void Turn(float horizontal, Rigidbody rigid)
    {
        AddForceSpin(horizontal, rigid);
    }

    public void Jump(Rigidbody rigid)
    {
        AddForceUp(rigid);
    }

    private void AddForceFront(Vector3 frontVec, float verticalValue, Rigidbody p_rigid)
    {
        Vector3 r = frontVec * verticalValue * moveSpeed;
        r.y = p_rigid.velocity.y;

        p_rigid.velocity = r;
    }

    private void AddForceSpin(float horizontalValue, Rigidbody p_rigid)
    {
        transform.Rotate(0, horizontalValue * turnSpeed, 0);
    }

    private void AddForceUp(Rigidbody p_rigid)
    {
        Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(JumpPower * -Physics.gravity.y);
        p_rigid.AddForce(jumpVelocity, ForceMode.Impulse);
    }
}
