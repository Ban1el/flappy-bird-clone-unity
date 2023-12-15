using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private UIController[] uiControllers;

    private void Awake()
    {
        uiControllers = GetComponentsInChildren<UIController>(true);
    }

    private void OnEnable()
    {
        Actions.SetUI += Set_UI_Display;
    }

    private void OnDisable()
    {
        Actions.SetUI -= Set_UI_Display;
    }

    private void Set_UI_Display(string ui_name, bool x)
    {
        foreach (UIController uiController in uiControllers)
        {
            if (ui_name == uiController.GetUIName())
            {
                uiController.Set_Active(x);
            }
        }
    }
}
