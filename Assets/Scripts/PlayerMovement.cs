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
        if (moveBool == true)
        {
            Walk(front, vertical, rigid);
            Turn(horizontal);
        }
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
}
