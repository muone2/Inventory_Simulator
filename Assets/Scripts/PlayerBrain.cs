using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody p_rigid;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject e;

    [SerializeField] float vertical = 0.0f;
    [SerializeField] float horizontal = 0.0f;
    [SerializeField] float jump = 0.0f;
    [SerializeField] float mouse = 0.0f;

    [SerializeField] Vector3 playerFrontVec;


    private void Update()
    {
        CheckInput();
        CheckPlayerFront();
        SeeItemGet();


        if (Input.GetMouseButton(0))
        {
            GameObject tmpobj = GetClickObj();
            if (tmpobj != null)
                Debug.Log(tmpobj.name);
            else
                Debug.Log("null");
        }
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
        mouse = Input.GetAxis("Fire1");
    }


    private GameObject GetClickObj()
    {
            RaycastHit hit;
            Vector3 middlePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z)));
            Vector3 startPoint = Camera.main.transform.position;
        Instantiate(e, middlePoint, Quaternion.Euler(Vector3.zero));

        if (Physics.Raycast(startPoint, middlePoint - startPoint, out hit))
            {
               // Debug.Log("hit point : " + hit.point + ", distance : " + hit.distance + ", name : " + hit.collider.name);
                Debug.DrawRay(startPoint, (middlePoint - startPoint) * hit.distance, Color.red);
                return hit.collider.gameObject;
            }
            else
            {
              //  Debug.DrawRay(startPoint, (middlePoint - startPoint) * 1000f, Color.red);
              //  Debug.Log("no");
                return null;
            }



            //  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            // Instantiate(e, point, Quaternion.Euler(Vector3.zero));
        
        // Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)));


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
