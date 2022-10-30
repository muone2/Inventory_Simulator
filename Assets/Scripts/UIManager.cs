using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text mouseItemName;

    public void ShowItemName(string targetName, Vector3 pos)
    {
        ShowItemNameSetPos(targetName, pos);
    }
    public void ShowItemNameNull()
    {
        ShowItemNameSetPos(null, Vector3.zero);
    }

    private void ShowItemNameSetPos(string name, Vector3 pos)
    {
        mouseItemName.text = name;
        mouseItemName.transform.position = Camera.main.WorldToScreenPoint(pos);

         //  Debug.Log(mouseItemName.transform.position);
    }
}
