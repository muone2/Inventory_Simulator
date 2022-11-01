using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerBrain playerBrain;

    [SerializeField] Text mouseItemName;
    [SerializeField] GameObject inventoryUI;

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

    public void OpenInventoryUI()
    {
        inventoryUI.SetActive(true);
        playerBrain.PlayerStop();
    }
    public void CloseInventoryUI()
    {
        inventoryUI.SetActive(false);
        playerBrain.PlayerStopEnd();
    }

}
