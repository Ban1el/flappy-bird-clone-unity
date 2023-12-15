using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private string ui_name;

    public string GetUIName()
    {
        return ui_name;
    }

    public void Set_Active(bool x)
    {
        this.gameObject.SetActive(x);
    }
}
