using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    [SerializeField] PlayerBrain playerBrain;

    [SerializeField] float vertical = 0.0f;
    [SerializeField] float horizontal = 0.0f;
    [SerializeField] bool JumpOn = false;
    [SerializeField] bool ClickOn = false;

    [SerializeField] RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        ShotRay();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
            JumpOn = true;
        if (Input.GetMouseButtonDown(0))
            ClickOn = true;
    }

    private void MovePlayer()
    {
        playerBrain.WalkPlayer(vertical);
        playerBrain.TurnPlayer(horizontal);
        if (JumpOn == true)
        {
            JumpOn = false;
            playerBrain.JumpPlayer();
        }
        if (ClickOn == true)
        {
            JumpOn = false;
            //playerBrain. 만들 예정인 아이템 줍는 함수
        }
    }

    private void ShotRay()
    {
        Vector3 middlePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z)));
        Vector3 startPoint = Camera.main.transform.position;
        //Instantiate(tmpObj, middlePoint, Quaternion.Euler(Vector3.zero));

        Debug.DrawRay(startPoint, (middlePoint - startPoint) * (middlePoint - startPoint).magnitude, Color.red);

        Physics.Raycast(startPoint, middlePoint - startPoint, out hit);
        playerBrain.SetTarget(hit);
    }
}
