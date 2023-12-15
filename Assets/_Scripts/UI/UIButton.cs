using UnityEngine;
using UnityEngine.UI;


public class UIButton : MonoBehaviour
{
    [SerializeField] private string button_name;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Actions.OnClick?.Invoke(button_name);
    }
}
