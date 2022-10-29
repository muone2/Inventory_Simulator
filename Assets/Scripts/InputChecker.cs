using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    [SerializeField] GameObject tmpObj;

    [SerializeField] float vertical = 0.0f;
    [SerializeField] float horizontal = 0.0f;
    [SerializeField] bool jump = false; //점프 도중인지 판단. (점프 도중이라면 true, 아니면 false, 점프가 끝나면 다시 false로 바뀜)
    //아니지... 이 스크립트는 점프 키에 대한 입력만 관리한다. 즉, 딱 한 순간만 들어갔다가 다시 꺼져야한다.
    //그렇지만 점프 키의 입력을 받을 것인지에 대한 것은 얘가 책임을 져야하지 않을까?
    //음... 그럼 이렇게 제어장치를 하나 더 두는 건 어떨까.
    [SerializeField] bool isCanJump = true;

    [SerializeField] float mouse = 0.0f;

    [SerializeField] RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        ShotRay();

        /*
        if (Input.GetMouseButton(0))
        {
            GameObject tmpobj = GetGameObjectHitRay();
            if (tmpobj != null)
                Debug.Log(tmpobj.name);
            else
                Debug.Log("null");
        }
*/
    }

    public float GetVertical()
    {
        return vertical;
    }
    public float GetHorizontal()
    {
        return horizontal;
    }
    public bool GetJump()
    {
        return jump;
    }

    public void ChangeIsCanJumpTrue()
    {
        isCanJump = true;
        jump = false;
    }


    private void CheckInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouse = Input.GetAxis("Fire1");

        if (Input.GetButtonDown("Jump") && isCanJump == true)
        {
            jump = true;
            isCanJump = false;
        }
    }




    public RaycastHit GetHitInfo()
    {
        return hit;
    }

    private void ShotRay()
    {
        Vector3 middlePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z)));
        Vector3 startPoint = Camera.main.transform.position;
        //Instantiate(tmpObj, middlePoint, Quaternion.Euler(Vector3.zero));

        Debug.DrawRay(startPoint, (middlePoint - startPoint) * (middlePoint - startPoint).magnitude, Color.red);
       
        Physics.Raycast(startPoint, middlePoint - startPoint, out hit);


        /*
        if (Physics.Raycast(startPoint, middlePoint - startPoint, out hit))
        {
            // Debug.Log("hit point : " + hit.point + ", distance : " + hit.distance + ", name : " + hit.collider.name);
            //return hit.collider.gameObject;
        }
        else
        {
            //  Debug.DrawRay(startPoint, (middlePoint - startPoint) * 1000f, Color.red);
            //  Debug.Log("no");
           // return null;
        }
        */


        //  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        // Instantiate(e, point, Quaternion.Euler(Vector3.zero));

        // Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)));


    }




}
