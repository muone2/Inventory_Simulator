using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerBrain playerBrain;
    // [SerializeField] InputChecker inputChecker;
    [SerializeField] Text mouseItemName;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowItemName();
    }

    private void ShowItemName()
    {
        GameObject tmp = playerBrain.GetTargetObj();

        if (tmp != null)
        {
            mouseItemName.text = tmp.name;
            mouseItemName.transform.position = Camera.main.WorldToScreenPoint(playerBrain.GetTargethitPoint());
           // Mathf.Abs(Camera.main.transform.position.z)
            //   Vector3 a =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z)));


         //  Debug.Log(mouseItemName.transform.position);
        }
        else
            mouseItemName.text = null;
    }

}
