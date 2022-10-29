using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    [SerializeField] GameObject tmpObj;

    [SerializeField] float vertical = 0.0f;
    [SerializeField] float horizontal = 0.0f;
    [SerializeField] float jump = 0.0f;
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
    public float GetJump()
    {
        return jump;
    }

    private void CheckInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        mouse = Input.GetAxis("Fire1");
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
